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

        public Transform leftRayOrigin;
        public Transform rightRayOrigin;
        public Handedness handedness;

        // Internal properties for drag management
        private bool m_IsDragging;
        private DraggableObject m_DragObject;

        public void Start()
        {
            // Respond to the events from the AppInputHandler
            m_AppInputHandler = AppInputHandler.Instance;

            // Create instances of the delegate methods
            m_PointerDown = PointerDown;
            m_PointerUp = PointerUp;

            m_AppInputHandler.pointerDown += m_PointerDown;
            m_AppInputHandler.pointerUp += m_PointerUp;

            // Set the layermask
            m_DraggableObjectLayerMask = LayerMask.GetMask(DRAGGABLE_OBJECT_LAYERMASK_STRING);
        }

        public void Update()
        {
            if (m_IsDragging)
            {
                UpdateDragObjectTransform();
            }
        }

        public void OnDestroy()
        {
            m_AppInputHandler.pointerDown -= m_PointerDown;
            m_AppInputHandler.pointerUp -= m_PointerUp;
        }

        private void PointerDown()
        {
            // Do a raycast
            Ray ray = new Ray(DominantHandRayOriginTransform.position, DominantHandRayOriginTransform.forward);

            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit, Mathf.Infinity, m_DraggableObjectLayerMask)) { return; }

            DraggableObject newDragObject = hit.collider.GetComponent<DraggableObject>();

            if (newDragObject == null) { return; }

            // Now that we have the draggable object, it should be moved by the DragHandler

            m_DragObject = newDragObject;

            m_IsDragging = true;

            // Start dragging
            DebugText.Log("\nStarted Dragging");
        }

        private void PointerUp()
        {
            if (!m_IsDragging) { return; }
            // Stop dragging

            m_IsDragging = false;

            DebugText.Log("| Stopped Dragging");
        }

        private void UpdateDragObjectTransform()
        {
            // Perform a raycast to move the drag object

        }

        private Transform DominantHandRayOriginTransform
        {
            get => handedness.isLeftHanded ? leftRayOrigin : rightRayOrigin;
        }
    }
}
