using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

namespace ShapeReality
{
    /// <summary>
    /// Sets wether the menu is attached to the right or left hand,
    /// and whether the ray interactor is attached to the right or left hand
    /// based on whether someone's dominant hand is left or right. 
    /// </summary>
    public class Handedness : MonoBehaviour
    {
        private static readonly string LEFT_HANDED_SETTING_KEY = "isLeftHanded";

        public Toggle leftHandedToggle;

        public bool m_IsLeftHanded = false;

        public GameObject m_LeftRecticle;
        public GameObject m_RightRecticle;

        public XRController m_LeftHandController;
        public XRController m_RightHandController;

        private void Start()
        {
            m_IsLeftHanded = PlayerPrefs.GetInt(LEFT_HANDED_SETTING_KEY) != 0;

            // Set the toggle value
            if (leftHandedToggle != null)
            {
                leftHandedToggle.SetIsOnWithoutNotify(m_IsLeftHanded);
            }
        }

        /// <summary>
        /// Set the handedness and store it to disk
        /// </summary>
        /// <param name="isLeftHanded"></param>
        public void SetHandedness(bool isLeftHanded)
        {
            m_IsLeftHanded = isLeftHanded;

            SetControllerRayInteractor(m_LeftHandController, isLeftHanded);
            SetControllerRayInteractor(m_RightHandController, !isLeftHanded);

            PlayerPrefs.SetInt(LEFT_HANDED_SETTING_KEY, (m_IsLeftHanded ? 1 : 0));
        }

        private void SetControllerRayInteractor(XRController controller, bool active)
        {
            controller.GetComponent<XRRayInteractor>().enabled = active;
            controller.GetComponent<LineRenderer>().enabled = active;
            controller.GetComponent<XRInteractorLineVisual>().enabled = active;
        }
    }
}
