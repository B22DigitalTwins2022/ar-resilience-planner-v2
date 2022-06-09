using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShapeReality
{
    /// <summary>
    /// Responsible for resetting the user study etc.
    /// </summary>
    public class UserStudy : MonoBehaviour
    {
        public DataLogger dataLogger;
        public Transform userStartPoint;
        public Transform xrOrigin;

        public FlyOver flyOver;

        public PanelSelector panelSelector;
        public Slider movementSpeedSlider;

        private SolutionManager m_SolutionManager;

        public void Start()
        {
            m_SolutionManager = SolutionManager.Instance;
        }

        public void ResetUserStudy()
        {
            dataLogger.ResetDataLogger();
            m_SolutionManager?.ResetAllSolutionSlots();


            Vector3 targetPos = userStartPoint.position;
            // Reset the position of the user
            flyOver.targetPosition = targetPos;
            xrOrigin.transform.position = targetPos;

            // Set the panel back to standard
            panelSelector.SetActivePanel(0);

            movementSpeedSlider.value = Constants.Values.DEFAULT_FLY_SPEED;
        }
    }
}

