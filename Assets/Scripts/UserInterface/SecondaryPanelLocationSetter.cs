using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    public class SecondaryPanelLocationSetter : MonoBehaviour
    {
        private Handedness m_Handedness;

        public Transform leftHandOffsetTransform;
        public Transform rightHandOffsetTransform;

        public Transform panel;

        private Handedness.OnHandednessChanged m_OnHandednessChanged;

        public void Start()
        {
            panel.localPosition = Vector3.zero;

            m_Handedness = Handedness.Instance;
            m_OnHandednessChanged = OnHandednessChanged;
            m_Handedness.onHandednessChanged += m_OnHandednessChanged;

            OnHandednessChanged(m_Handedness.isLeftHanded);
        }

        public void OnDestroy()
        {
            m_Handedness.onHandednessChanged -= m_OnHandednessChanged;
        }

        public void OnHandednessChanged(bool isLeftHanded)
        {
            Transform targetTransform = isLeftHanded ? leftHandOffsetTransform : rightHandOffsetTransform;
            panel.SetParent(targetTransform, false);
        }
    }

}

