using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ShapeReality
{
    public class SimulationPanel : MonoBehaviour
    {
        private static SimulationPanel _instance;
        public static SimulationPanel Instance { get { return _instance; } }

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

        public TextMeshProUGUI weatherText;
    }
}

