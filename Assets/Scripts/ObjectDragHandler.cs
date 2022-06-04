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
            // Do a raycast

            m_IsDragging = true;

            // Start dragging
            DebugText.Log("\nPointerDown");
        }

        private void PointerUp()
        {
            // Stop dragging

            m_IsDragging = false;

            DebugText.Log("| PointerUp");
        }
    }
}
