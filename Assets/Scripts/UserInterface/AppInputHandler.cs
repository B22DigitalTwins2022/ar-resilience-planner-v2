using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShapeReality
{
    public class AppInputHandler : MonoBehaviour, AppInput.ILeftHandActions, AppInput.IRightHandActions
    {
        // Singleton behaviour
        private static AppInputHandler _instance;
        public static AppInputHandler Instance { get { return _instance; } }

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

        private AppInput m_AppInput;

        public void OnEnable()
        {
            if (m_AppInput == null)
            {
                m_AppInput = new AppInput();
                m_AppInput.LeftHand.SetCallbacks(this);
                m_AppInput.RightHand.SetCallbacks(this);

                m_AppInput.LeftHand.Enable();
                m_AppInput.RightHand.Enable();
            }
        }

        public void OnDisable()
        {
            m_AppInput.LeftHand.Disable();
            m_AppInput.RightHand.Disable();
        }

        public Handedness handedness; // To determine whether to fire the event, based on which hand is currently active

        public delegate void PointerDown();
        public delegate void PointerUp();
        public delegate void ToggleMenu();
        public delegate void OnFly(Vector2 flyVector);

        public PointerDown pointerDown;
        public PointerUp pointerUp;
        public ToggleMenu toggleMenu;
        public OnFly onFlyStart;
        public OnFly onFlyEnd;

        public Transform leftHandRayOrigin;
        public Transform rightHandRayOrigin;

        public static Transform PrimaryHandRayOrigin
        {
            get
            {
                AppInputHandler handler = Instance;
                Transform t = handler.handedness.isLeftHanded ? handler.leftHandRayOrigin : handler.rightHandRayOrigin;
                return t;
            }
        }

        void AppInput.ILeftHandActions.OnToggleMenu(InputAction.CallbackContext context)
        {
            if (!context.performed) { return; }

            if (!handedness.isLeftHanded)
            {
                toggleMenu.Invoke();
            }
        }

        void AppInput.IRightHandActions.OnToggleMenu(InputAction.CallbackContext context)
        {
            if (!context.performed) { return; }
            
            if (handedness.isLeftHanded)
            {
                toggleMenu.Invoke();
            }
        }

        void AppInput.ILeftHandActions.OnPointerDown(InputAction.CallbackContext context)
        {
            if (!context.performed) { return; }

            if (handedness.isLeftHanded)
            {
                pointerDown.Invoke();
            }
        }

        void AppInput.ILeftHandActions.OnPointerUp(InputAction.CallbackContext context)
        {
            if (!context.performed) { return; }

            if (handedness.isLeftHanded)
            {
                pointerUp.Invoke();
            }
        }

        void AppInput.IRightHandActions.OnPointerDown(InputAction.CallbackContext context)
        {
            if (!context.performed) { return; }

            if (!handedness.isLeftHanded)
            {
                pointerDown.Invoke();
            }
        }

        void AppInput.IRightHandActions.OnPointerUp(InputAction.CallbackContext context)
        {
            if (!context.performed) { return; }

            if (!handedness.isLeftHanded)
            {
                pointerUp.Invoke();
            }
        }



        void AppInput.ILeftHandActions.OnFly(InputAction.CallbackContext context)
        {
            if (!handedness.isLeftHanded) { return; }
            Vector2 flyVector = context.ReadValue<Vector2>();

            if (context.performed)
            {
                onFlyStart.Invoke(flyVector);
            } else if (context.canceled)
            {
                onFlyEnd.Invoke(flyVector);
            }
        }

        void AppInput.IRightHandActions.OnFly(InputAction.CallbackContext context)
        {
            if (handedness.isLeftHanded) { return; }
            Vector2 flyVector = context.ReadValue<Vector2>();

            if (context.performed)
            {
                onFlyStart.Invoke(flyVector);
            }
            else if (context.canceled)
            {
                onFlyEnd.Invoke(flyVector);
            }
        }
    }
}

