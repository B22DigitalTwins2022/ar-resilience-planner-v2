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
