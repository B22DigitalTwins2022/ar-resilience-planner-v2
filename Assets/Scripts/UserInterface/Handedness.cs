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
        private static Handedness _instance;
        public static Handedness Instance { get { return _instance; } }

        private static readonly string LEFT_HANDED_SETTING_KEY = "isLeftHanded";

        public Toggle leftHandedToggle;

        public bool isLeftHanded = false;

        public GameObject m_LeftRecticle;
        public GameObject m_RightRecticle;

        public GameObject m_Menu;

        public ActionBasedController m_LeftHandController;
        public ActionBasedController m_RightHandController;

        public Transform m_LeftControllerRayOrigin;
        public Transform m_RightControllerRayOrigin;

        public delegate void OnHandednessChanged(bool isLeftHanded);

        public OnHandednessChanged onHandednessChanged;

        public void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
            }
        }

        public void Start()
        {
            if (PlayerPrefs.HasKey(LEFT_HANDED_SETTING_KEY))
            {
                isLeftHanded = PlayerPrefs.GetInt(LEFT_HANDED_SETTING_KEY) != 0;
            }

            // Set the toggle value
            if (leftHandedToggle != null)
            {
                leftHandedToggle.SetIsOnWithoutNotify(isLeftHanded);
            }

            SetHandedness(isLeftHanded);
        }

        /// <summary>
        /// Set the handedness and store it to disk
        /// </summary>
        /// <param name="isLeftHanded"></param>
        public void SetHandedness(bool isLeftHanded)
        {
            this.isLeftHanded = isLeftHanded;

            SetControllerRayInteractor(m_LeftHandController, isLeftHanded);
            SetControllerRayInteractor(m_RightHandController, !isLeftHanded);

            // Set the menu to the right hand
            Transform menuHand = isLeftHanded ? m_RightControllerRayOrigin : m_LeftControllerRayOrigin;
            m_Menu.transform.SetParent(menuHand, false);

            m_LeftRecticle.SetActive(isLeftHanded);
            m_RightRecticle.SetActive(!isLeftHanded);

            PlayerPrefs.SetInt(LEFT_HANDED_SETTING_KEY, this.isLeftHanded ? 1 : 0);
            if (onHandednessChanged != null)
            {
                onHandednessChanged.Invoke(this.isLeftHanded);
            }
            
        }

        private void SetControllerRayInteractor(ActionBasedController controller, bool active)
        {
            controller.GetComponent<XRRayInteractor>().enabled = active;
            controller.GetComponent<LineRenderer>().enabled = active;
            controller.GetComponent<CustomXRInteractorLineVisual>().enabled = active;
        }
    }
}
