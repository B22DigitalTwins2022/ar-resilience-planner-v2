using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    /// <summary>
    /// Main class that is responsible for the simulation of the environment
    /// Keeps track of temperature (generate heatmap?) based on the added
    /// solutions (SolutionDropZones)
    /// </summary>
    public class ClimateSimulation : MonoBehaviour
    {
        private Solution3DSlot[] solutionSlots;

        public void Start()
        {
            // Find all Solution3DSlots
            solutionSlots = FindObjectsOfType<Solution3DSlot>();
        }

        /// <summary>
        /// Run the simulation
        /// </summary>
        public void UpdateSimulation()
        {

        }

    }
}