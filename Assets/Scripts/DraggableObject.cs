using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace ShapeReality
{
    public class DraggableObject : XRBaseInteractable
    {
        private const string DEFAULT_LAYERMASK_STRING = "Default";
        private const string DRAGGING_OBJECT_LAYERMASK_STRING = "DraggingObject";

        private LayerMask m_DefaultLayerMask;
        private LayerMask m_DefaultLayerMaskIndex;
        private LayerMask m_DraggingObjectLayerMask;
        private LayerMask m_DraggingObjectLayerMaskIndex;

        //private IXRInteractor m_Interactor;
        private Transform m_RayOriginTransform;
        private bool m_IsDragging;

        private MeshRenderer m_Renderer;

        public void Start()
        {
            m_DefaultLayerMask = LayerMask.GetMask(DEFAULT_LAYERMASK_STRING);
            m_DefaultLayerMaskIndex = LayerMask.NameToLayer(DEFAULT_LAYERMASK_STRING);
            m_DraggingObjectLayerMask = LayerMask.GetMask(DRAGGING_OBJECT_LAYERMASK_STRING);
            m_DraggingObjectLayerMaskIndex = LayerMask.NameToLayer(DRAGGING_OBJECT_LAYERMASK_STRING);
            m_Renderer = GetComponent<MeshRenderer>();
        }

        public void Update()
        {
            if (m_IsDragging)
            {
                UpdateObjectTransform();
            }
        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);
            

            m_Renderer.material.color = Color.blue;

            m_RayOriginTransform = args.interactorObject.GetAttachTransform(this);
            gameObject.layer = m_DraggingObjectLayerMaskIndex;
            //DebugText.Log(string.Format("{0}", gameObject.layer));
            m_IsDragging = true;
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            //DebugText.Log(string.Format("{0}", gameObject.layer));


            m_IsDragging = false;

            m_Renderer.material.color = Color.white;

            gameObject.layer = m_DefaultLayerMaskIndex;
        }

        private void UpdateObjectTransform()
        {
            if (m_RayOriginTransform == null) { return; }
            // Update the transform based on the raycast etc

            // Perform a raycast into the scene
            RaycastHit hit;

            if (Physics.Raycast(InteractorRay, out hit, Mathf.Infinity, m_DefaultLayerMask))
            {
                // A hit has been made, see if it is a dropzone, otherwise just move it to the place
                DropZone dropZone = hit.collider.GetComponent<DropZone>();

                // Interpolate these positions (look at XR Interaction Toolkit for reference
                if (dropZone != null)
                {
                    // Align it to the dropzone
                    transform.position = dropZone.transform.position;
                } else
                {
                    // Just move it to the aimed at location
                    transform.position = hit.point;
                }
            }
        }

        private Ray InteractorRay
        {
            get => new(m_RayOriginTransform.position, m_RayOriginTransform.forward);
        }
    }
}