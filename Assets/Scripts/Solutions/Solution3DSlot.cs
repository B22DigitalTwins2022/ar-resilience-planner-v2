using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    /// <summary>
    /// This is the object that should be hovered (raycasted) by the SolutionUIObject so that it 
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public class Solution3DSlot : MonoBehaviour
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

