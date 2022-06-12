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

        private float m_TargetZOffset;

        private const float HOVER_SPEED = 0.1f;
        private const float HOVER_Z_OFFSET = 0.4f;
        private const float HOVER_SINE_AMPLITUDE = 0.2f;

        #region States
        private bool m_SolutionIsHighlighted;
        public bool SolutionIsHighlighted
        {
            get => m_SolutionIsHighlighted;
            set
            {
                m_SolutionIsHighlighted = value;
                SetSolutionHighlightedVisual(m_SolutionIsHighlighted);
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
                solutionGameObject.SetActive(m_SolutionIsHovered);
            }
        }

        private bool m_SolutionIsActive;
        public bool SolutionIsActive
        {
            get => m_SolutionIsActive;
            set
            {
                m_SolutionIsActive = value;
                SetSolutionVisibility(m_SolutionIsActive);
            }
        }
        #endregion

        public void Update()
        {
            if (m_SolutionIsHovered)
            {
                // Update target position based on the hover value
                m_TargetZOffset = HOVER_Z_OFFSET + Mathf.Sin(TimeUtils.TimeMultiplier * HOVER_SPEED) * HOVER_SINE_AMPLITUDE;
            } else
            {
                m_TargetZOffset = 0;
            }

            if (Smoothing.Interpolate(solutionGameObject.transform.localPosition.z, m_TargetZOffset, out float zOffset, Constants.Values.SMOOTH_TIME_HOVER))
            {
                solutionGameObject.transform.localPosition.SetZ(zOffset);
            }
        }

        public void SetSolutionHighlightedVisual(bool visibility)
        {
            highlightVisual.SetActive(visibility);
        }

        public void SetSolutionHover(bool hover)
        {

        }

        

        public void SetSolutionActive(bool active)
        {
            SolutionIsActive = active;
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

        private void SetSolutionVisibility(bool visible)
        {
            solutionGameObject.SetActive(visible);
        }
    }
}

