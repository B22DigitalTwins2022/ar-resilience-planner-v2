using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    public class ContinuousUserPosition : MonoBehaviour
    {
        public bool logging;

        public void Start()
        {
            // Start logging data

            StartCoroutine(LogUserPosition());
        }

        IEnumerator LogUserPosition()
        {
            while (logging)
            {
                DataLogger.Log(DataLogger.continuousUserPositionLogFile, 1.1f, 2.3f, -0.3f, 30.3f, 12f, 0.138223f, "DraggableObject (1)");
                yield return new WaitForSeconds(Constants.Intervals.CONTINUOUS_LOGGING_INTERVAL);
            }

        }
    }

}

