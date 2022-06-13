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

        

        //private SolutionManager m_SolutionManager;

        public void Start()
        {
            //m_SolutionManager = SolutionManager.Instance;
            ResetUserStudy();
        }

        public void ResetUserStudy()
        {
            dataLogger.ResetDataLogger();

            StartCoroutine(ResetDelayed(1f));


            Vector3 targetPos = userStartPoint.position;
            // Reset the position of the user
            flyOver.targetPosition = targetPos;
            xrOrigin.transform.position = targetPos;
            xrOrigin.transform.rotation = userStartPoint.rotation;

            // Set the panel back to standard
            panelSelector.SetActivePanel(0);

            movementSpeedSlider.value = Constants.Values.DEFAULT_FLY_SPEED;
        }

        private IEnumerator ResetDelayed(float time)
        {
            yield return new WaitForSeconds(time);

            SolutionManager.Instance.ResetAllSolutionSlots();
        }
    }
}

