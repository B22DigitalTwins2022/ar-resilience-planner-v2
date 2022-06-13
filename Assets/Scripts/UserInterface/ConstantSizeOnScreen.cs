using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    /// <summary>
    /// This class takes the initial scale of the object on the screen and scales it based on the set size in pixels
    /// It will always stay the same size on screen. 
    /// </summary>
    public class ConstantSizeOnScreen : MonoBehaviour
    {
        public float sizeInPixels;

        private Vector3 m_InitialScale;

        protected void Awake()
        {
            m_InitialScale = transform.localScale;
            UpdateScale();
        }

        protected void Update()
        {
            UpdateScale();
        }

        public void UpdateScale()
        {
            float sizeInMeters = sizeInPixels / GetPixelsPerMeter(transform.position, Camera.main);

            transform.localScale = m_InitialScale * sizeInMeters;
        }

        /// <summary>
        /// Get the amount of pixels one meter spans at a certain world position
        /// </summary>
        /// <param name="position"></param>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static float GetPixelsPerMeter(Vector3 position, Camera camera)
        {
            Vector3 deltaPosition = camera.transform.position - position;
            Vector3 cameraForward = camera.transform.forward;
            Vector3 projectedVector = Vector3.Project(deltaPosition, cameraForward);

            float distanceBetweenCameraAndObjectInMeters = projectedVector.magnitude;

            // This distance should be projected onto the camera forward vector

            float fovInRadians = camera.fieldOfView * Mathf.Deg2Rad;
            float screenHeightInPixels = camera.pixelHeight;

            float screenHeightInMeters = 2 * distanceBetweenCameraAndObjectInMeters * Mathf.Tan(fovInRadians / 2);

            return screenHeightInPixels / screenHeightInMeters;
        }
    }
}