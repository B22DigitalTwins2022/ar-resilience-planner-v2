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
        public Solution solution;
        public SolutionsPanel solutionsPanel;

        public RectTransform hoverOffset;

        public GameObject hoverVisual;

        //public Renderer hoverVisualRenderer;

        private float m_TargetZPosition = 0.0f;
        private float m_CurrentZPosition = 0.0f;

        //private float m_TargetHoverAlpha = 0.0f;
        //private float m_CurrentHoverAlpha = 0.0f;
        //private const float HOVER_ALPHA = 0.4f;
        //private Color hoverColor;

        private float m_EndpointSmoothingTime = 0.02f;

        private const float HOVER_UI_HEIGHT = -0.3f;


        private bool m_IsHovering;

        public void Start()
        {
            hoverVisual.SetActive(false);
            //hoverColor = hoverVisualRenderer.material.color;
            //hoverVisualRenderer.material.color = SetAlpha(hoverColor, 0);
        }

        public void Update()
        {
            if (Interpolate(m_CurrentZPosition, m_TargetZPosition, out float z))
            {
                m_CurrentZPosition = z;
                hoverOffset.localPosition = SetZ(hoverOffset.localPosition, z);
            }

            //if (Interpolate(m_TargetHoverAlpha, m_CurrentHoverAlpha, out float alpha))
            //{
            //    hoverVisualRenderer.material.color = SetAlpha(hoverColor, alpha);
            //}
        }


        
        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);
            m_TargetZPosition = HOVER_UI_HEIGHT;
            hoverVisual.SetActive(true);
            m_IsHovering = true;
            //m_TargetHoverAlpha = HOVER_ALPHA;
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);
            m_TargetZPosition = 0.0f;
            hoverVisual.SetActive(false);
            m_IsHovering = false;
            //m_TargetHoverAlpha = 0.0f;
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            if (m_IsHovering)
            {
                hoverVisual.SetActive(false);
            }
            
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            if (m_IsHovering)
            {
                hoverVisual.SetActive(true);
            }
            
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

        //private Color SetAlpha(Color color, float alpha)
        //{
        //    return new Color(color.r, color.g, color.b, alpha);
        //}
    }
}
