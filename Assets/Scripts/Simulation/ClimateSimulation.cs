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

        public float basetemperature = 34f;

        public float totalCost;
        public float totalRunningCost;
        public float adjustedTemperature;
        public float totalBiodiversity;
        public float totalDrainage;

        private const string degreesCelsius = "°C";


        public void UpdateSimulation(SolutionModel[] solutionModels)
        {
            adjustedTemperature = basetemperature;
            foreach (SolutionModel solutionModel in solutionModels)
            {
                adjustedTemperature += solutionModel.temperatureImpact;
            }

            SimulationPanel.Instance.weatherText.text = adjustedTemperature.ToString("0.0") + degreesCelsius;
            DataLogger.Log(DataLogger.simulationLogFile, basetemperature, totalBiodiversity, adjustedTemperature, totalDrainage, totalCost, totalRunningCost);
        }
    }
}