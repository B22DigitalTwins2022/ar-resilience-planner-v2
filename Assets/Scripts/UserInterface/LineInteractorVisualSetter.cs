using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    /// <summary>
    /// Sets the color of the ray and reticle based on whether the pointer is down or not
    /// </summary>
    public class LineInteractorVisualSetter : MonoBehaviour
    {
        private AppInputHandler m_AppInputHandler;
        private AppInputHandler.PointerDown m_PointerDown;
        private AppInputHandler.PointerUp m_PointerUp;

        // References to the ray and reticle
        [Header("Ray and Reticle Appearance")]
        public MeshRenderer leftReticle;
        public MeshRenderer rightReticle;
        public LineRenderer leftRay;
        public LineRenderer rightRay;

        public Gradient defaultRayGradient;
        public Gradient draggingRayGradient;
        public Color defaultReticleColor;
        public Color draggingReticleColor;

        private bool m_PointerIsPressed;

        public void Start()
        {
            // Respond to the events from the AppInputHandler
            m_AppInputHandler = AppInputHandler.Instance;

            // Create instances of the delegate methods
            m_PointerDown = PointerDown;
            m_PointerUp = PointerUp;

            m_AppInputHandler.pointerDown += m_PointerDown;
            m_AppInputHandler.pointerUp += m_PointerUp;

            SetRayAndReticleColor(false);
        }

        public void OnDestroy()
        {
            m_AppInputHandler.pointerDown -= m_PointerDown;
            m_AppInputHandler.pointerUp -= m_PointerUp;
        }

        private void PointerDown()
        {
            m_PointerIsPressed = true;
            SetRayAndReticleColor(m_PointerIsPressed);
        }

        private void PointerUp()
        {
            m_PointerIsPressed = false;
            SetRayAndReticleColor(m_PointerIsPressed);
        }

        private void SetRayAndReticleColor(bool isDragging)
        {
            Color targetColor = isDragging ? draggingReticleColor : defaultReticleColor;
            Gradient targetGradient = isDragging ? draggingRayGradient : defaultRayGradient;

            SetReticleColor(targetColor);
            SetRayGradient(targetGradient);
        }

        private void SetReticleColor(Color color)
        {
            leftReticle.material.color = color;
            rightReticle.material.color = color;
        }

        private void SetRayGradient(Gradient gradient)
        {
            leftRay.colorGradient = gradient;
            rightRay.colorGradient = gradient;
        }
    }
}
