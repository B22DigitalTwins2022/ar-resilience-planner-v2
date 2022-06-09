using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    public class ContinuousUserPositionLogger : MonoBehaviour
    {
        public bool logging = true;

        public Transform headsetTransform;

        public void Start()
        {
            // Start logging data

            StartCoroutine(LogUserPosition());
        }

        IEnumerator LogUserPosition()
        {
            
            while (logging)
            {
                RaycastHit hit;
                Ray ray = new Ray(headsetTransform.position, headsetTransform.forward);
                string raycastObject = "NaN";
                if (Physics.Raycast(ray, out hit))
                {
                    raycastObject = hit.collider.gameObject.name;
                }

                DataLogger.Log(DataLogger.continuousUserPositionLogFile,
                    headsetTransform.position.x,
                    headsetTransform.position.y,
                    headsetTransform.position.z,
                    headsetTransform.rotation.x,
                    headsetTransform.rotation.y,
                    headsetTransform.rotation.z, raycastObject);
                yield return new WaitForSeconds(Constants.Values.CONTINUOUS_LOGGING_INTERVAL);
            }
        }
    }
}

