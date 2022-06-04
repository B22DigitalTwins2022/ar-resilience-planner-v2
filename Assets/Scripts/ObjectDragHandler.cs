using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ShapeReality
{
    /// <summary>
    /// The ObjectDragHandler is responsible for raycasting on PointerDown,
    /// creating a drag instance of the to be dragged instance and then
    /// </summary>
    public class ObjectDragHandler : MonoBehaviour
    {
        public const string DRAGGABLE_OBJECT_LAYERMASK_STRING = "DraggableObject";

        private LayerMask m_DraggableObjectLayerMask;

        private AppInputHandler m_AppInputHandler;
        private AppInputHandler.PointerDown m_PointerDown;
        private AppInputHandler.PointerUp m_PointerUp;

        public TextMeshPro debugText;

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

        // Internal properties for drag management
        private bool m_IsDragging;

        public void Start()
        {
            // Respond to the events from the AppInputHandler
            m_AppInputHandler = AppInputHandler.Instance;

            // Create instances of the delegate methods
            m_PointerDown = PointerDown;
            m_PointerUp = PointerUp;

            m_AppInputHandler.pointerDown += m_PointerDown;
            m_AppInputHandler.pointerUp += m_PointerUp;
        }

        public void OnDestroy()
        {
            m_AppInputHandler.pointerDown -= m_PointerDown;
            m_AppInputHandler.pointerUp -= m_PointerUp;
        }

        private void PointerDown()
        {
            

            m_IsDragging = true;

            SetRayAndReticleColor(m_IsDragging);

            // Start dragging
            debugText.text += "\nPointerDown";
        }

        private void PointerUp()
        {
            // Stop dragging

            m_IsDragging = false;

            SetRayAndReticleColor(m_IsDragging);

            debugText.text += "\nPointerUp";
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
