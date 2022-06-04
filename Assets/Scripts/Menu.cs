using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShapeReality
{
    public class Menu : MonoBehaviour
    {
        private static readonly string MENU_OPEN_SETTING_KEY = "menuOpen";

        public Handedness handedness;
        public GameObject menuOffset;

        

        private bool m_MenuIsOpen = false;



        public void Start()
        {
            if (PlayerPrefs.HasKey(MENU_OPEN_SETTING_KEY))
            {
                m_MenuIsOpen = PlayerPrefs.GetInt(MENU_OPEN_SETTING_KEY) != 0;
            }

            SetMenuOpened(m_MenuIsOpen);

            AppInputHandler.Instance.toggleMenu += ToggleMenu;
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