using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace ShapeReality
{
    public class DraggableObject : XRBaseInteractable
    {
        public void Start()
        {
            
        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);
            DebugText.Log("onHoverEntered");
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);
            DebugText.Log("onHoverExited");
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);
            DebugText.Log("onSelectEntered");
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            DebugText.Log("onSelectExited");
        }

        //protected override void OnHover
    }
}