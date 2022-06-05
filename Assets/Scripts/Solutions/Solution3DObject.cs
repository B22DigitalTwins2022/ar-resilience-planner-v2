using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace ShapeReality
{
    /// <summary>
    /// This is the solution that is placed in the 3D space and can be dragged around
    /// </summary>
    public class Solution3DObject : XRBaseInteractable
    {
        public Transform offsetTransform;
        public MeshRenderer meshRenderer;
        public Collider childCollider;

        public Color selectedColor;

        private Transform m_RayOriginTransform;
        private bool m_IsDragging;

        public void Start()
        {
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
            

            meshRenderer.material.color = selectedColor;

            m_RayOriginTransform = args.interactorObject.GetAttachTransform(this);
            childCollider.gameObject.layer = Constants.Layers.draggingIndex;
            //DebugText.Log(string.Format("{0}", gameObject.layer));
            m_IsDragging = true;
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            //DebugText.Log(string.Format("{0}", gameObject.layer));


            m_IsDragging = false;

            meshRenderer.material.color = Color.white;

            childCollider.gameObject.layer = Constants.Layers.defaultIndex;
        }

        private void UpdateObjectTransform()
        {
            if (m_RayOriginTransform == null) { return; }
            // Update the transform based on the raycast etc

            // Perform a raycast into the scene
            RaycastHit hit;

            if (Physics.Raycast(InteractorRay, out hit, Mathf.Infinity, Constants.Layers.@default))
            {
                // A hit has been made, see if it is a dropzone, otherwise just move it to the place
                Solution3DSlot slot = hit.collider.GetComponent<Solution3DSlot>();

                // Interpolate these positions (look at XR Interaction Toolkit for reference
                if (slot != null)
                {
                    // Align it to the dropzone
                    transform.position = slot.transform.position;
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