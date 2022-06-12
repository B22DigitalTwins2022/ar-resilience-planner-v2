using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ShapeReality.Utils;

namespace ShapeReality
{
    /// <summary>
    /// This class is a last resort for the user test so that people can fly through the city
    /// </summary>
    public class FlyOver : MonoBehaviour
    {
        public float moveSpeed = Constants.Values.DEFAULT_FLY_SPEED;

        public void SetMoveSpeed(float setMoveSpeed)
        {
            moveSpeed = setMoveSpeed;
        }

        private AppInputHandler m_AppInputHandler;
        private AppInputHandler.OnFly m_OnFlyStart;
        private AppInputHandler.OnFly m_OnFlyEnd;

        public Transform transformToMove;
        public Transform transformForGettingRotation;

        public Vector3 targetPosition;

        private bool m_IsFlying;

        private Vector2 m_StoredMultiplier;

        public void Start()
        {
            m_AppInputHandler = AppInputHandler.Instance;

            m_OnFlyStart = OnFlyStart;
            m_OnFlyEnd = OnFlyEnd;

            m_AppInputHandler.onFlyStart += m_OnFlyStart;
            m_AppInputHandler.onFlyEnd += m_OnFlyEnd;

            targetPosition = transformToMove.position;
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
                Vector3 sidewaysDirection = transformForGettingRotation.right;
                Vector3 deltaPosition = headsetDirection * m_StoredMultiplier.y * moveSpeed;
                deltaPosition += sidewaysDirection * m_StoredMultiplier.x * moveSpeed;
                
                targetPosition += deltaPosition * TimeUtils.TimeMultiplier;
            }

            Vector3 pos;
            if (Smoothing.Interpolate(transformToMove.position, targetPosition, out pos, Constants.Values.SMOOTH_TIME_FLYING))
            {
                transformToMove.position = pos;
            }
        }

        private void OnFlyStart(Vector2 flyVector)
        {
            // Update xrOriginTransform based on the current
            m_IsFlying = true;
            m_StoredMultiplier = flyVector;
        }

        private void OnFlyEnd(Vector2 flyVector)
        {
            m_StoredMultiplier = Vector2.zero;
            m_IsFlying = false;
        }

        
    }

}

