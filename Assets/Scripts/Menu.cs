using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShapeReality
{
    public class Menu : MonoBehaviour, XRIDefaultInputActions.IXRILeftHandInteractionActions, XRIDefaultInputActions.IXRIRightHandInteractionActions
    {
        private XRIDefaultInputActions m_InputActions;

        public void OnEnable()
        {
            if (m_InputActions == null)
            {
                m_InputActions = new XRIDefaultInputActions();
                m_InputActions.XRILeftHandInteraction.SetCallbacks(this);
                m_InputActions.XRIRightHandInteraction.SetCallbacks(this);
            }
        }

        void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnActivate(InputAction.CallbackContext context) { } // Activate is bound to the trigger
        void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnActivateValue(InputAction.CallbackContext context) { }
        void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnRotateAnchor(InputAction.CallbackContext context) { }
        void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnSelect(InputAction.CallbackContext context) { } // Select is bound to the grip button
        void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnSelectValue(InputAction.CallbackContext context) { }
        void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnTranslateAnchor(InputAction.CallbackContext context) { }
        void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnUIPress(InputAction.CallbackContext context) { } // Bound to the trigger
        void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnUIPressValue(InputAction.CallbackContext context) { }

        void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnActivate(InputAction.CallbackContext context) { } // Activate is bound to the trigger
        void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnActivateValue(InputAction.CallbackContext context) { }
        void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnRotateAnchor(InputAction.CallbackContext context) { }
        void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnSelect(InputAction.CallbackContext context) { } // Select is bound to the grip button
        void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnSelectValue(InputAction.CallbackContext context) { }
        void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnTranslateAnchor(InputAction.CallbackContext context) { }
        void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnUIPress(InputAction.CallbackContext context) { } // Bound to the trigger
        void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnUIPressValue(InputAction.CallbackContext context) { }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}