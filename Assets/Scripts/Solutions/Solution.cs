using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    [CreateAssetMenu(fileName = "Solution", menuName = "ARResiliencePlanner/Solution")]
    public class Solution : ScriptableObject
    {
        public string title;
        public string description;
        public Sprite picture;
        public GameObject modelPreviewPrefab;
        public GameObject modelPrefab;

        // Costs
        public float upfrontCost;
        public float maintenanceCost;

        // Benefits
        public float biodiversity;
        public float temperature;
        public float waterDrainage;
    }

}
