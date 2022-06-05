using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    [RequireComponent(typeof(MeshRenderer))]
    public class DropZone : MonoBehaviour
    {
        private MeshRenderer m_MeshRenderer;

        public void OnEnable()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
            //SetDropZoneVisibility(false);
        }

        public void SetDropZoneVisibility(bool visibility)
        {
            m_MeshRenderer.enabled = visibility;
        }
    }

}
