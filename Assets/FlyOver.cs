using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShapeReality
{
    /// <summary>
    /// This class is a last resort for the user test so that people can fly through the city
    /// </summary>
    public class FlyOver : MonoBehaviour
    {
        public float moveSpeed = 0.05f;

        private AppInputHandler m_AppInputHandler;
        private AppInputHandler.OnFly m_OnFly;

        public Transform xrOriginTransform;
        public Transform headsetTransform;

        private float m_EndpointSmoothingTime = 0.02f;

        private Vector3 m_TargetPosition;

        public void Start()
        {
            m_AppInputHandler = AppInputHandler.Instance;

            m_OnFly = OnFly;

            m_AppInputHandler.onFly += m_OnFly;

            m_TargetPosition = xrOriginTransform.position;
        }

        public void OnDestroy()
        {
            m_AppInputHandler.onFly -= m_OnFly;
        }

        public void Update()
        {
            Vector3 pos;
            if (Interpolate(xrOriginTransform.position, m_TargetPosition, out pos))
            {
                xrOriginTransform.position = pos;
            }
        }

        private void OnFly(Vector2 flyVector)
        {
            // Update xrOriginTransform based on the current

            Vector3 headsetDirection = headsetTransform.forward;

            float multiplier = flyVector.y * moveSpeed;

            Vector3 deltaPosition = headsetDirection * multiplier;

            m_TargetPosition += deltaPosition;
        }

        private bool Interpolate(Vector3 current, Vector3 target, out Vector3 output)
        {
            if (Vector3.Distance(target, current) > Mathf.Epsilon)
            {
                var velocity = Vector3.zero;
                output = Vector3.SmoothDamp(current, target, ref velocity, m_EndpointSmoothingTime);
                return true;
            }
            output = Vector3.zero;
            return false;
        }
    }

}

