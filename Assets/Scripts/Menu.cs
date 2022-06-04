using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShapeReality
{
    public class Menu : MonoBehaviour, AppInput.ILeftHandActions, AppInput.IRightHandActions
    {
        private static readonly string MENU_OPEN_SETTING_KEY = "menuOpen";

        public Handedness handedness;
        public GameObject menuOffset;

        private AppInput m_AppInput;

        private bool m_MenuIsOpen = false;


        public void OnEnable()
        {
            if (m_AppInput == null)
            {
                m_AppInput = new AppInput();
                m_AppInput.LeftHand.SetCallbacks(this);
                m_AppInput.RightHand.SetCallbacks(this);

                m_AppInput.LeftHand.Enable();
                m_AppInput.RightHand.Enable();
            }
        }


        public void OnDisable()
        {
            m_AppInput.LeftHand.Disable();
            m_AppInput.RightHand.Disable();
        }


        public void Start()
        {
            if (PlayerPrefs.HasKey(MENU_OPEN_SETTING_KEY))
            {
                m_MenuIsOpen = PlayerPrefs.GetInt(MENU_OPEN_SETTING_KEY) != 0;
            }

            SetMenuOpened(m_MenuIsOpen);
        }


        void AppInput.ILeftHandActions.OnToggleMenu(InputAction.CallbackContext context)
        {
            if (!handedness.isLeftHanded)
            {
                ToggleMenu();
            }
        }

        void AppInput.IRightHandActions.OnToggleMenu(InputAction.CallbackContext context)
        {
            if (handedness.isLeftHanded)
            {
                ToggleMenu();
            }
        }


        private void SetMenuOpened(bool menuIsOpen)
        {
            m_MenuIsOpen = menuIsOpen;

            menuOffset.SetActive(menuIsOpen);

            PlayerPrefs.SetInt(MENU_OPEN_SETTING_KEY, m_MenuIsOpen ? 1 : 0);
        }


        private void ToggleMenu()
        {
            SetMenuOpened(!m_MenuIsOpen);
        }
    }
}