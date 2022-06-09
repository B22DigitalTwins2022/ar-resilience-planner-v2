using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    [CreateAssetMenu(fileName = "Solution", menuName = "ARResiliencePlanner/Solution")]
    public class Solution : ScriptableObject
    {
        /// <summary>
        /// These types are used for matching the selected solution from the UI with the slots in the 3d space. 
        /// </summary>
        public enum SolutionType
        {
            BuildingGreenCoverBalkony,
            UrbanFarms,
            GreenRoof,
            Park,
            GreenShadeSolution,
            Trees,
            WaterChannels
        }

        public string title;
        public string description;
        public Sprite picture;

        public SolutionType solutionType;

        [Header("Models")]
        public GameObject modelPreviewPrefab;

        [Header("Costs")]
        public float upfrontCost;
        public float maintenanceCost;

        [Header("Benefits")]
        public float biodiversity;
        public float temperature;
        public float waterDrainage;
    }
}
