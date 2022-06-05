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
        //public const string DRAGGABLE_OBJECT_LAYERMASK_STRING = "DraggableObject";
        //public const string DROP_ZONE_LAYERMASK_STRING = "DropZone";

        //private LayerMask m_DraggableObjectLayerMask;
        //private LayerMask m_DropZoneLayerMask;

        //private AppInputHandler m_AppInputHandler;
        //private AppInputHandler.PointerDown m_PointerDown;
        //private AppInputHandler.PointerUp m_PointerUp;

        public Transform leftRayOrigin;
        public Transform rightRayOrigin;
        public Handedness handedness;

        // Internal properties for drag management
        private bool m_IsDragging;
        private DraggableObject m_DragObject;

        public void Start()
        {
            // Set the layermask
            //m_DraggableObjectLayerMask = LayerMask.GetMask(DRAGGABLE_OBJECT_LAYERMASK_STRING);
            //m_DropZoneLayerMask = LayerMask.GetMask(DROP_ZONE_LAYERMASK_STRING);
        }

        public void Update()
        {
            /*if (m_IsDragging)
            {
                UpdateDragObjectTransform();
            }*/
        }

        public void OnDestroy()
        {
            //m_AppInputHandler.pointerDown -= m_PointerDown;
            //m_AppInputHandler.pointerUp -= m_PointerUp;
        }

        /*private void PointerDown()
        {
            // Do a raycast for the draggable objects
            RaycastHit hit;

            if (!Raycast(out hit)) { return; }

            DraggableObject newDragObject = hit.collider.GetComponent<DraggableObject>();

            if (newDragObject == null) { return; }

            // Now that we have the draggable object, it should be moved by the DragHandler

            m_DragObject = newDragObject;

            m_DragObject.GetComponent<MeshRenderer>().material.color = Color.blue;

            m_IsDragging = true;

            // Start dragging
            DebugText.Log("\nStarted Dragging");
        }

        private void PointerUp()
        {
            if (!m_IsDragging) { return; }
            // Stop dragging

            m_IsDragging = false;

            m_DragObject.GetComponent<MeshRenderer>().material.color = Color.white;


            m_DragObject = null;
            DebugText.Log("| Stopped Dragging");
        }*/

        /*private void UpdateDragObjectTransform()
        {
            // Perform a raycast to move the drag object
            RaycastHit dropZoneHit;
            if (Raycast(out dropZoneHit))
            {
                DropZone dropZone = dropZoneHit.collider.GetComponent<DropZone>();
                if (dropZone != null)
                {
                    // The drop zone has been found, do something with it
                    m_DragObject.transform.position = dropZone.transform.position;
                }
            }

            // Otherwise make the object float in the air
        }*/
        /*
        private bool Raycast(out RaycastHit hit)
        {
            Ray ray = new Ray(DominantHandRayOriginTransform.position, DominantHandRayOriginTransform.forward);
            return Physics.Raycast(ray, out hit, Mathf.Infinity);
        }*/
        /*
        private Transform DominantHandRayOriginTransform
        {
            get => handedness.isLeftHanded ? leftRayOrigin : rightRayOrigin;
        }*/
    }
}
