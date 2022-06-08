using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    /// <summary>
    /// Responsible for resetting the user study etc.
    /// </summary>
    public class UserStudy : MonoBehaviour
    {
        public DataLogger dataLogger;

        public void ResetUserStudy()
        {
            dataLogger.ResetDataLogger();
            SolutionManager solutionManager = SolutionManager.Instance;
            if (solutionManager != null)
            {
                solutionManager.ResetAllSolutionSlots();
            }

        }
    }

}

