using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using ShapeReality.Utils;

namespace ShapeReality
{
    /// <summary>
    /// This is the solution that is present in the "Add solutions" panel in the
    /// menu. 
    /// </summary>
    public class SolutionUIObject : XRBaseInteractable
    {
        private SolutionManager m_SolutionManager;

        private Solution m_Solution;

        public Solution solution
        {
            get
            {
                return m_Solution;
            }
            set
            {
                m_Solution = value;
                UpdateSolutionUI();
            }
        }
        public SolutionsPanel solutionsPanel;

        private GameObject m_SolutionUIModel;

        public RectTransform hoverOffset;
        public GameObject hoverVisual;
        private bool m_IsHovering;
        
        private float m_TargetZPosition = 0.0f;
        private float m_CurrentZPosition = 0.0f;
        private const float HOVER_UI_HEIGHT = -0.3f;

        private bool m_IsPlacingSolutionModel;
        private GameObject m_SolutionPreview;

        private Vector3 m_SolutionPreviewTargetPosition;
        private Vector3 m_SolutionPreviewTargetScale;

        private Transform m_RayOriginTransform;
        private SolutionModel m_SolutionModel;
        RaycastHit[] m_RaycastResults = new RaycastHit[50];

        private Ray RayFromPrimaryController { get => new(m_RayOriginTransform.position, m_RayOriginTransform.forward); }


        public void Start()
        {
            hoverVisual.SetActive(false);
            m_SolutionManager = SolutionManager.Instance;
        }


        public void Update()
        {
            if (Smoothing.Interpolate(m_CurrentZPosition, m_TargetZPosition, out float z, Constants.Values.SMOOTH_TIME_HOVER))
            {
                m_CurrentZPosition = z;
                hoverOffset.localPosition = hoverOffset.localPosition.SetZ(z);
            }

            if (m_IsPlacingSolutionModel)
            {
                UpdatePlacingSolution();
            }
        }

        private void UpdatePlacingSolution()
        {
            // Use the rayOriginTransform to show the object in front of the controller
            m_SolutionPreviewTargetPosition = RayFromPrimaryController.GetPoint(Constants.Values.PLACING_SOLUTION_MODEL_DISTANCE);

            UpdateSolutionPreviewPosition();
            // Also perform a raycast whether a solutionmodel is underneath
            /*if (RaycastSolutionModel(out SolutionModel solutionModel))
            {
                if (!solutionModel.SolutionIsActive)
                {

                }
                if (m_SolutionModel != null)
                {
                    m_SolutionModel.SetSolutionActive(false);
                }
                m_SolutionModel = solutionModel;
                m_SolutionModel.SetSolutionActive(true);
            }*/

            
        }

        private void UpdateSolutionPreviewPosition()
        {
            if (m_SolutionPreview == null) { return; }
            if (Smoothing.Interpolate(m_SolutionPreview.transform.position,
                m_SolutionPreviewTargetPosition,
                out Vector3 position, Constants.Values.SMOOTH_TIME_PREVIEW_MOVE))
            {
                m_SolutionPreview.transform.position = position;
            }
        }

        #region XR Interactable implementation
        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);
            m_TargetZPosition = HOVER_UI_HEIGHT;
            hoverVisual.SetActive(true);
            m_IsHovering = true;
            solutionsPanel.ShowSolutionDescription(solution);

            DataLogger.Log(DataLogger.actionsLogFile, "OnHoverEnter SolutionUIObject", solution.name);
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            
            base.OnHoverExited(args);
            m_TargetZPosition = 0.0f;
            hoverVisual.SetActive(false);
            m_IsHovering = false;
            solutionsPanel.HideSolutionDescription();

            DataLogger.Log(DataLogger.actionsLogFile, "OnHoverExit SolutionUIObject", solution.name);
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            if (m_IsHovering)
            {
                hoverVisual.SetActive(false);
                StartPlacingSolutionModel(args);

                DataLogger.Log(DataLogger.actionsLogFile, "OnSelectEntered SolutionUIObject", solution.name); // This means that this object has been dragged into the scene
            }
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            if (m_IsHovering)
            {
                hoverVisual.SetActive(true);

                DataLogger.Log(DataLogger.actionsLogFile, "OnSelectExited SolutionUIObject", solution.name);
            }

            if (m_IsPlacingSolutionModel)
            {
                StopPlacingSolutionModel();
            }
        }
        #endregion


        private void StartPlacingSolutionModel(SelectEnterEventArgs args)
        {
            m_SolutionManager.StartSolutionTypeHighlight(solution.solutionType);
            m_IsPlacingSolutionModel = true;
            m_SolutionUIModel.SetActive(false);

            m_SolutionPreview = Instantiate(solution.modelPreviewPrefab, null, false);
            m_SolutionPreview.transform.localScale = Vector3.one * Constants.Values.PLACING_SOLUTION_MODEL_SCALE;
            m_SolutionPreview.transform.position = m_SolutionUIModel.transform.position;

            m_RayOriginTransform = AppInputHandler.PrimaryHandRayOrigin;
        }

        private void StopPlacingSolutionModel()
        {
            m_SolutionManager.StopSolutionTypeHighlight(solution.solutionType);
            m_IsPlacingSolutionModel = false;
            m_SolutionUIModel.SetActive(true);

            Destroy(m_SolutionPreview);

            m_SolutionModel = null;
        }


        #region Helper methods
        private void UpdateSolutionUI()
        {
            if (m_SolutionUIModel != null)
            {
                Destroy(m_SolutionUIModel);
                m_SolutionUIModel = null;
            }
            if (m_Solution.modelPreviewPrefab != null)
            {
                m_SolutionUIModel = Instantiate(m_Solution.modelPreviewPrefab, hoverOffset, false);
            }
        }

        private bool RaycastSolutionModel(out SolutionModel solutionModel)
        {
            solutionModel = null;
            int hitsAmount = Physics.RaycastNonAlloc(RayFromPrimaryController, m_RaycastResults, Mathf.Infinity, Constants.Layers.solutionModel);

            float closestDistance = Mathf.Infinity;

            for (int i = 0; i < hitsAmount; i++)
            {
                RaycastHit hit = m_RaycastResults[i];
                SolutionModel hitSolutionModel = hit.collider.GetComponent<SolutionModel>();

                if ((hitSolutionModel.solutionType == solution.solutionType) && (hit.distance < closestDistance))
                {
                    closestDistance = hit.distance;
                    solutionModel = hitSolutionModel;
                }
            }

            return solutionModel != null;
        }

        #endregion
    }
}
