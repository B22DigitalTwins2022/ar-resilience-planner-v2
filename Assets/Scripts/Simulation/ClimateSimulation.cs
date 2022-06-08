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
        //private SolutionModel[] solutionSlots;

        /*public void Start()
        {
            // Find all Solution3DSlots
            solutionSlots = FindObjectsOfType<SolutionModel>();
        }

        /// <summary>
        /// Run the simulation
        /// </summary>
        public void UpdateSimulation()
        {

        }*/
        // Singleton behaviour
        private static ClimateSimulation _instance;
        public static ClimateSimulation Instance { get { return _instance; } }

        private void Awake()
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

        public void UpdateSimulation()
        {
            
        }
    }
}