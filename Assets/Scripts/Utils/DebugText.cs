using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ShapeReality
{
    [RequireComponent(typeof(TextMeshPro))]
    public class DebugText : MonoBehaviour
    {
        // Singleton behaviour
        private static DebugText _instance;
        public static DebugText Instance { get { return _instance; } }

        private TextMeshPro text;

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

            text = GetComponent<TextMeshPro>();
        }

        public static void Log(string logString)
        {
            Instance.text.text += string.Format("{0} | ", logString);
        }
    }
}

