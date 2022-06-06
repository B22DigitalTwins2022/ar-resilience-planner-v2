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
        private const float DRAG_DISTANCE_FROM_USER = 0.6f;
        private const float DRAG_MODEL_SCALE = 0.4f;

        private Solution m_Solution;
        public Solution solution
        {
            get => m_Solution;
            set
            {
                m_Solution = value;
                OnSolutionChanged();
            }
        }

        public Transform offsetTransform;
        public MeshRenderer meshRenderer;

        public GameObject solutionInstantiated3DModel;

        public Color selectedColor;

        public Transform rayOriginTransform;

        private AppInputHandler m_AppInputHandler;
        private AppInputHandler.PointerUp m_PointerUp;

        private bool m_IsDragging;
        public bool IsDragging
        {
            get => m_IsDragging;
            set
            {
                m_IsDragging = value;
                OnDraggingChanged(m_IsDragging);
            }
        }

        public void Start()
        {
            m_AppInputHandler = AppInputHandler.Instance;
            m_PointerUp = PointerUp;
            m_AppInputHandler.pointerUp += m_PointerUp;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            m_AppInputHandler.pointerUp -= m_PointerUp;
        }

        public void Update()
        {
            if (IsDragging)
            {
                UpdateTransform();
            }
        }

        private void OnDraggingChanged(bool isDragging)
        {
            float scale = isDragging ? DRAG_MODEL_SCALE : 1.0f;

            if (solutionInstantiated3DModel != null)
            {
                solutionInstantiated3DModel.transform.localScale = Vector3.one * scale;
            }
        }

        //protected override void OnSelectEntered(SelectEnterEventArgs args)
        //{
        //    base.OnSelectEntered(args);

            

        //}

        //protected override void OnSelectExited(SelectExitEventArgs args)
        //{
        //    base.OnSelectExited(args);

        //    IsDragging = false;

        //}

        private void PointerUp()
        {
            IsDragging = false;
        }

        private void UpdateTransform()
        {
            Ray ray = new Ray(rayOriginTransform.position, rayOriginTransform.forward);

            Vector3 newPosition = ray.GetPoint(DRAG_DISTANCE_FROM_USER);

            transform.position = newPosition;
        }

        private void OnSolutionChanged()
        {
            if (solutionInstantiated3DModel != null)
            {
                Destroy(solutionInstantiated3DModel);
            }

            if (solution.modelPrefab != null)
            {
                solutionInstantiated3DModel = Instantiate(solution.modelPrefab, offsetTransform, false);
                solutionInstantiated3DModel.transform.localPosition = Vector3.zero;
            }
        }
    }
}