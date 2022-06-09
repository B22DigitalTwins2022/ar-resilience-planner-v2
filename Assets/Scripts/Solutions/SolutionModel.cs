using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
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

        public GameObject hoverVisual;
        public GameObject solutionGameObject;

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

        public void SetHoverVisualVisibility(bool visibility)
        {
            hoverVisual.SetActive(visibility);
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

