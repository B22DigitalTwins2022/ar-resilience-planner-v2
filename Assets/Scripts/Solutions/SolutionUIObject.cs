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

        public GameObject impactVisual;
        private GameObject m_ImpactVisualGameObject;
        
        private float m_TargetZPosition = 0.0f;
        private float m_CurrentZPosition = 0.0f;
        private const float HOVER_UI_HEIGHT = -0.3f;
        private static readonly Quaternion SOLUTION_PREVIEW_ORIENTATION = Quaternion.Euler(-90f, 0f, 180f);

        private bool m_IsPlacingSolutionModel;
        private GameObject m_SolutionPreview;

        private TransformValues m_SolutionPreviewTargetTransform;

        private Transform m_RayOriginTransform;
        private SolutionModel m_SolutionModel;
        RaycastHit[] m_RaycastResults = new RaycastHit[20];

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
            m_SolutionPreviewTargetTransform.Position = RayFromPrimaryController.GetPoint(Constants.Values.PLACING_SOLUTION_MODEL_DISTANCE);
            m_SolutionPreviewTargetTransform.Rotation = SOLUTION_PREVIEW_ORIENTATION;
            m_SolutionPreviewTargetTransform.Scale = Vector3.one * Constants.Values.PLACING_SOLUTION_MODEL_SCALE;

            
            // Also perform a raycast whether a solutionmodel is underneath
            if (RaycastSolutionModel(out SolutionModel solutionModel, out Vector3 hitPosition) && !m_IsHovering)
            {
                if (m_SolutionModel != null && m_SolutionModel != solutionModel)
                {
                    m_SolutionModel.SolutionIsHovered = false;
                }
                if (solutionModel.SolutionIsActive == false)
                {
                    m_SolutionModel = solutionModel;
                    m_SolutionPreviewTargetTransform.Position = hitPosition;
                    m_SolutionPreviewTargetTransform.Scale = Vector3.one * Constants.Values.PLACING_SOLUTION_HOVER_MODEL_SCALE;

                    m_SolutionModel.SolutionIsHovered = true;
                    m_ImpactVisualGameObject.SetActive(true);
                }
            }
            else
            {
                m_ImpactVisualGameObject.SetActive(false);
                // Deactivate the previous solution model
                if (m_SolutionModel != null)
                {
                    m_SolutionModel.SolutionIsHovered = false;
                    m_SolutionModel = null;
                }
            }
            
            UpdateSolutionPreviewPosition();
        }

        private void UpdateSolutionPreviewPosition()
        {
            if (m_SolutionPreview == null) { return; }

            if (Smoothing.Interpolate(new TransformValues(m_SolutionPreview.transform),
                m_SolutionPreviewTargetTransform,
                out TransformValues transformValues, Constants.Values.SMOOTH_TIME_PREVIEW_MODEL_TRANSFORM))
            {
                m_SolutionPreview.transform.SetFromValues(transformValues);
                m_ImpactVisualGameObject.transform.position = transformValues.Position;
                m_ImpactVisualGameObject.transform.LookAt(Camera.main.transform, Vector3.up);
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
            m_ImpactVisualGameObject = Instantiate(impactVisual, null, false);
            m_SolutionPreviewTargetTransform = new TransformValues(m_SolutionUIModel.transform);
            m_SolutionPreview.transform.SetFromValues(m_SolutionPreviewTargetTransform);

            m_SolutionPreviewTargetTransform.Scale = Vector3.one * Constants.Values.PLACING_SOLUTION_MODEL_SCALE;
            m_SolutionPreviewTargetTransform.Rotation = SOLUTION_PREVIEW_ORIENTATION;

            m_RayOriginTransform = AppInputHandler.PrimaryHandRayOrigin;
        }

        private void StopPlacingSolutionModel()
        {
            m_SolutionManager.StopSolutionTypeHighlight(solution.solutionType);
            m_IsPlacingSolutionModel = false;
            m_SolutionUIModel.SetActive(true);

            Destroy(m_SolutionPreview);
            Destroy(m_ImpactVisualGameObject);

            if (m_SolutionModel != null)
            {
                m_SolutionModel.SolutionIsHovered = false;
                m_SolutionModel.SolutionIsActive = true;
            }

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

        private bool RaycastSolutionModel(out SolutionModel solutionModel, out Vector3 hitPosition)
        {
            solutionModel = null;
            hitPosition = Vector3.zero;
            int hitsAmount = Physics.RaycastNonAlloc(RayFromPrimaryController, m_RaycastResults, Mathf.Infinity, Constants.Layers.solutionModel);

            float closestDistance = Mathf.Infinity;

            for (int i = 0; i < hitsAmount; i++)
            {
                RaycastHit hit = m_RaycastResults[i];
                
                if (!hit.collider.TryGetComponent<SolutionModel>(out var hitSolutionModel))
                {
                    hitSolutionModel = hit.collider.GetComponentInParent<SolutionModel>();
                }

                if ((hitSolutionModel.solutionType == solution.solutionType) && (hit.distance < closestDistance))
                {
                    closestDistance = hit.distance;
                    hitPosition = hit.point;
                    solutionModel = hitSolutionModel;
                }
            }

            return solutionModel != null;
        }

        #endregion
    }
}
