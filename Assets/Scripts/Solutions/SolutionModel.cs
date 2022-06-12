using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShapeReality
{
    using Utils;

    /// <summary>
    /// This is the object that should be hovered (raycasted) by the SolutionUIObject so that it 
    /// </summary>
    public class SolutionModel : MonoBehaviour
    {
        public Solution.SolutionType solutionType;

        public float biodiversityImpact;
        public float temperatureImpact;
        public float drainageImpact;
        public float cost;
        public float runningCost;

        public GameObject highlightVisual;
        public GameObject solutionGameObject;

        private float m_TargetYOffset;

        private const float HOVER_SPEED = 3f;
        private const float HOVER_Y_OFFSET = 1f;
        private const float HOVER_SINE_AMPLITUDE = 0.5f;

        #region States
        private bool m_SolutionIsHighlighted;
        public bool SolutionIsHighlighted
        {
            get => m_SolutionIsHighlighted;
            set
            {
                m_SolutionIsHighlighted = value;
                OnSetSolutionHighlighted(m_SolutionIsHighlighted);
            }
        }

        private bool m_SolutionIsHovered;
        public bool SolutionIsHovered
        {
            get => m_SolutionIsHovered;
            set
            {
                if (value == m_SolutionIsHovered) { return; }
                m_SolutionIsHovered = value;
                OnSetSolutionHover(m_SolutionIsHovered);
            }
        }

        private bool m_SolutionIsActive;
        public bool SolutionIsActive
        {
            get => m_SolutionIsActive;
            set
            {
                m_SolutionIsActive = value;
                OnSetSolutionActive(m_SolutionIsActive);
            }
        }
        #endregion

        public void Update()
        {
            if (SolutionIsHovered)
            {
                // Update target position based on the hover value
                m_TargetYOffset = HOVER_Y_OFFSET + Mathf.Sin(Time.time * HOVER_SPEED) * HOVER_SINE_AMPLITUDE;
                solutionGameObject.transform.localPosition = solutionGameObject.transform.localPosition.SetY(m_TargetYOffset);
            }

            if (SolutionIsActive)
            {
                if (Smoothing.Interpolate(solutionGameObject.transform.localPosition.y, m_TargetYOffset, out float y, Constants.Values.SMOOTH_TIME_HOVER))
                {
                    solutionGameObject.transform.localPosition = solutionGameObject.transform.localPosition.SetY(y);
                }
            }
        }

        private void OnSetSolutionHover(bool hover)
        {
            if (!hover) { m_TargetYOffset = 0; }
            if (SolutionIsActive) return; // don't disable the object when the solution is active
            solutionGameObject.SetActive(hover);
        }

        private void OnSetSolutionHighlighted(bool highlighted)
        {
            highlightVisual.SetActive(highlighted);
        }

        private void OnSetSolutionActive(bool active)
        {
            solutionGameObject.SetActive(active);
            if (active)
            {
                DataLogger.Log(DataLogger.actionsLogFile,
                "Activated SolutionModel (name, type, biodiversity, temp, drainage, cost, running-cost)",
                    name,
                    solutionType,
                    biodiversityImpact,
                    temperatureImpact,
                    drainageImpact,
                    cost,
                    runningCost);
            } else
            {
                DataLogger.Log(DataLogger.actionsLogFile,
                    "Deactivated SolutionsModel", name);
            }
            
            ClimateSimulation.Instance.UpdateSimulation();
        }
    }
}

