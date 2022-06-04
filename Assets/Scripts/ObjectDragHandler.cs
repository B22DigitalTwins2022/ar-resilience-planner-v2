using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            // Start dragging
        }

        private void PointerUp()
        {
            // Stop dragging
        }
    }
}
