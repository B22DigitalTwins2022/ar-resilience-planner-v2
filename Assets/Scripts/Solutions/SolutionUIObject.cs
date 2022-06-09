using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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
                UpdateSolutionAppearance();
            }
        }
        public SolutionsPanel solutionsPanel;

        private GameObject m_InstantiatedPreviewModel;

        public RectTransform hoverOffset;
        public GameObject hoverVisual;
        private bool m_IsHovering;
        
        private float m_TargetZPosition = 0.0f;
        private float m_CurrentZPosition = 0.0f;
        private float m_EndpointSmoothingTime = Constants.Values.END_POINT_SMOOTHING_TIME_HOVER;
        private const float HOVER_UI_HEIGHT = -0.3f;

        private bool m_IsPlacingSolutionModel;


        public void Start()
        {
            hoverVisual.SetActive(false);

            m_SolutionManager = SolutionManager.Instance;
        }

        private void UpdateSolutionAppearance()
        {
            if (m_InstantiatedPreviewModel != null)
            {
                Destroy(m_InstantiatedPreviewModel);
                m_InstantiatedPreviewModel = null;
            }
            if (m_Solution.modelPreviewPrefab != null)
            {
                m_InstantiatedPreviewModel = Instantiate(m_Solution.modelPreviewPrefab, hoverOffset, false);
            }
            
            
        }

        public void Update()
        {
            if (Interpolate(m_CurrentZPosition, m_TargetZPosition, out float z))
            {
                m_CurrentZPosition = z;
                hoverOffset.localPosition = SetZ(hoverOffset.localPosition, z);
            }
        }

        
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
                m_SolutionManager.StopSolutionHover(solution.solutionType);
                m_IsPlacingSolutionModel = false;
            }
        }

        private void StartPlacingSolutionModel(SelectEnterEventArgs args)
        {
            m_SolutionManager.StartSolutionHover(solution.solutionType);
            m_IsPlacingSolutionModel = true;

            /*Solution3DObject solution3DObject = Instantiate(solution3DObjectPrefab, null, false).GetComponent<Solution3DObject>();
            solution3DObject.solution = solution;
            solution3DObject.rayOriginTransform = args.interactorObject.GetAttachTransform(this);
            solution3DObject.IsDragging = true;*/
        }

        // Methods for interpolating smoothly

        private bool Interpolate(float current, float target, out float output)
        {
            if (Mathf.Abs(target - current) > Mathf.Epsilon)
            {
                var velocity = 0.0f;
                output = Mathf.SmoothDamp(current, target, ref velocity, m_EndpointSmoothingTime);
                return true;
            }
            output = 0;
            return false;
        }

        private Vector3 SetZ(Vector3 vector, float zComponent)
        {
            return new Vector3(vector.x, vector.y, zComponent);
        }
    }
}
