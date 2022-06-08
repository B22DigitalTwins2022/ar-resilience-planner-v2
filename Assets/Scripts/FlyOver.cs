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

        public void SetMoveSpeed(float setMoveSpeed)
        {
            moveSpeed = setMoveSpeed;
        }

        private AppInputHandler m_AppInputHandler;
        private AppInputHandler.OnFly m_OnFlyStart;
        private AppInputHandler.OnFly m_OnFlyEnd;

        public Transform transformToMove;
        public Transform transformForGettingRotation;

        private float m_EndpointSmoothingTime = 0.02f;

        private Vector3 m_TargetPosition;

        private bool m_IsFlying;

        private float m_StoredMultiplier;

        public void Start()
        {
            m_AppInputHandler = AppInputHandler.Instance;

            m_OnFlyStart = OnFlyStart;
            m_OnFlyEnd = OnFlyEnd;

            m_AppInputHandler.onFlyStart += m_OnFlyStart;
            m_AppInputHandler.onFlyEnd += m_OnFlyEnd;

            m_TargetPosition = transformToMove.position;
        }

        public void OnDestroy()
        {
            m_AppInputHandler.onFlyStart -= m_OnFlyStart;
            m_AppInputHandler.onFlyEnd -= m_OnFlyEnd;
        }

        public void Update()
        {
            if (m_IsFlying)
            {
                Vector3 headsetDirection = transformForGettingRotation.forward;
                Vector3 deltaPosition = headsetDirection * m_StoredMultiplier * moveSpeed;
                m_TargetPosition += deltaPosition;
            }

            Vector3 pos;
            if (Interpolate(transformToMove.position, m_TargetPosition, out pos))
            {
                transformToMove.position = pos;
            }
        }

        private void OnFlyStart(Vector2 flyVector)
        {
            // Update xrOriginTransform based on the current
            m_IsFlying = true;
            m_StoredMultiplier = flyVector.y;
        }

        private void OnFlyEnd(Vector2 flyVector)
        {
            m_StoredMultiplier = 0f;
            m_IsFlying = false;
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

