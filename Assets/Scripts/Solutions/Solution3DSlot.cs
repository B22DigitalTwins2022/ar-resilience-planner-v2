using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Solution3DSlot : MonoBehaviour
    {
        private MeshRenderer m_MeshRenderer;

        public Solution3DObject currentlyHeldObject;

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

