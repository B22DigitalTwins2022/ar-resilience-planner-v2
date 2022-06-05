using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ShapeReality
{
    public class PanelSelector : MonoBehaviour
    {
        private static readonly string ACTIVE_PANEL_SETTING_KEY = "activePanel";

        public Color defaultPanelButtonColor;
        public Color activePanelButtonColor;

        public GameObject[] panels;

        public Button[] panelButtons;

        public int activePanelIndex = 0;

        private GameObject activePanel;
        private Button activePanelButton;

        public void Start()
        {
            InitializeButtons();

            DeactivateAllPanels();

            if (PlayerPrefs.HasKey(ACTIVE_PANEL_SETTING_KEY))
            {
                activePanelIndex = PlayerPrefs.GetInt(ACTIVE_PANEL_SETTING_KEY);
            }

            SetActivePanel(activePanelIndex);
        }

        private void DeactivateAllPanels()
        {
            foreach (GameObject panel in panels)
            {
                panel.SetActive(false);
            }
        }

        public void InitializeButtons()
        {
            // Set the background color
            for (int i=0; i < panelButtons.Length; i++)
            {
                Button panelButton = panelButtons[i];

                panelButton.GetComponent<Image>().color = defaultPanelButtonColor;
                int index = i;
                panelButton.onClick.AddListener(() => { SetActivePanel(index); });
            }
        }

        public void SetActivePanel(int index)
        {
            if (index >= panels.Length) { return; } // out of bounds

            // Switch active panel
            if (activePanel != null)
            {
                activePanel.SetActive(false);
            }

            if (activePanelButton != null)
            {
                activePanelButton.GetComponent<Image>().color = defaultPanelButtonColor;
            }

            activePanel = panels[index];
            activePanel.SetActive(true);

            activePanelButton = panelButtons[index];
            activePanelButton.GetComponent<Image>().color = activePanelButtonColor;

            PlayerPrefs.SetInt(ACTIVE_PANEL_SETTING_KEY, activePanelIndex);
        }
    }

}
