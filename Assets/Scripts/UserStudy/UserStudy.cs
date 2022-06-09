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

            // Reset the position of the user
            xrOrigin.transform.position = userStartPoint.position;

            // Set the panel back to standard
            panelSelector.SetActivePanel(0);

            movementSpeedSlider.value = Constants.Values.DEFAULT_FLY_SPEED;
        }
    }
}

