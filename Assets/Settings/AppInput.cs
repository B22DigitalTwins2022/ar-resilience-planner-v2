//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Settings/AppInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace ShapeReality
{
    public partial class @AppInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @AppInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""AppInput"",
    ""maps"": [
        {
            ""name"": ""LeftHand"",
            ""id"": ""49c89128-926e-4615-9ea6-d146629b0e00"",
            ""actions"": [
                {
                    ""name"": ""ToggleMenu"",
                    ""type"": ""Button"",
                    ""id"": ""0c26715b-1bd7-49d6-8575-062aee127619"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PointerDown"",
                    ""type"": ""Button"",
                    ""id"": ""b3448788-a392-4425-a3c6-2393fda40883"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PointerUp"",
                    ""type"": ""Button"",
                    ""id"": ""fd879619-ae74-4ff2-8b39-8ed2cad9d77e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a3a895f4-d950-4175-992b-6d526b9f1e71"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""ToggleMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19aa2d11-40bd-40d2-b84d-019ce06dfa3d"",
                    ""path"": ""<XRController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""ToggleMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fbe833f-8364-4ed1-ad20-c1bee1e68cbf"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af94d24d-55c8-4451-8ece-bf0ac404ebb2"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cd73b63-733a-42af-ad18-52b90e43efc1"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8aa6eac4-7500-4736-b437-6de7720cd601"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc61e767-60dd-4209-ba5f-3d608b199e4f"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e261d01-918e-4f27-a955-e4ca393fc08a"",
                    ""path"": ""<XRController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1017e53a-f9e3-4a42-8953-a3818d216161"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74f7cb06-f63c-4056-a87d-3e15318a1583"",
                    ""path"": ""<XRController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""RightHand"",
            ""id"": ""5b62d2b5-9bc7-442e-987c-501e86f5c6b6"",
            ""actions"": [
                {
                    ""name"": ""ToggleMenu"",
                    ""type"": ""Button"",
                    ""id"": ""c5eabf96-96d1-4047-98cc-aa12ffcc9dce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PointerDown"",
                    ""type"": ""Button"",
                    ""id"": ""ed7d468b-1f0c-4026-a316-f809447a8006"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PointerUp"",
                    ""type"": ""Button"",
                    ""id"": ""02885757-63d2-44ce-8185-caa9396029a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7da5e4c1-1e04-46e5-a48c-6c680112f5ff"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""ToggleMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d889731-aced-41b2-96bc-c66069ad6a6d"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""ToggleMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb20cd1a-019e-479b-8696-818f05c4db87"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f06e09b7-0824-40a8-a469-b28f2f3615ed"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ab9e29e-e30f-4cec-a4d9-a96effbd3842"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04f9fe1d-b7e4-4f53-83ac-07060f869649"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37426f42-e907-4205-b513-343443523df5"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5965d24-26b9-412b-8f6c-78e3a7306d50"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2215bfc5-9eda-4895-bb45-6dda85565259"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40a679ff-e875-4ac4-be84-3357bf6186c9"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""PointerDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Generic XR Controller"",
            ""bindingGroup"": ""Generic XR Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>{LeftHand}"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XRController>{RightHand}"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // LeftHand
            m_LeftHand = asset.FindActionMap("LeftHand", throwIfNotFound: true);
            m_LeftHand_ToggleMenu = m_LeftHand.FindAction("ToggleMenu", throwIfNotFound: true);
            m_LeftHand_PointerDown = m_LeftHand.FindAction("PointerDown", throwIfNotFound: true);
            m_LeftHand_PointerUp = m_LeftHand.FindAction("PointerUp", throwIfNotFound: true);
            // RightHand
            m_RightHand = asset.FindActionMap("RightHand", throwIfNotFound: true);
            m_RightHand_ToggleMenu = m_RightHand.FindAction("ToggleMenu", throwIfNotFound: true);
            m_RightHand_PointerDown = m_RightHand.FindAction("PointerDown", throwIfNotFound: true);
            m_RightHand_PointerUp = m_RightHand.FindAction("PointerUp", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // LeftHand
        private readonly InputActionMap m_LeftHand;
        private ILeftHandActions m_LeftHandActionsCallbackInterface;
        private readonly InputAction m_LeftHand_ToggleMenu;
        private readonly InputAction m_LeftHand_PointerDown;
        private readonly InputAction m_LeftHand_PointerUp;
        public struct LeftHandActions
        {
            private @AppInput m_Wrapper;
            public LeftHandActions(@AppInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @ToggleMenu => m_Wrapper.m_LeftHand_ToggleMenu;
            public InputAction @PointerDown => m_Wrapper.m_LeftHand_PointerDown;
            public InputAction @PointerUp => m_Wrapper.m_LeftHand_PointerUp;
            public InputActionMap Get() { return m_Wrapper.m_LeftHand; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LeftHandActions set) { return set.Get(); }
            public void SetCallbacks(ILeftHandActions instance)
            {
                if (m_Wrapper.m_LeftHandActionsCallbackInterface != null)
                {
                    @ToggleMenu.started -= m_Wrapper.m_LeftHandActionsCallbackInterface.OnToggleMenu;
                    @ToggleMenu.performed -= m_Wrapper.m_LeftHandActionsCallbackInterface.OnToggleMenu;
                    @ToggleMenu.canceled -= m_Wrapper.m_LeftHandActionsCallbackInterface.OnToggleMenu;
                    @PointerDown.started -= m_Wrapper.m_LeftHandActionsCallbackInterface.OnPointerDown;
                    @PointerDown.performed -= m_Wrapper.m_LeftHandActionsCallbackInterface.OnPointerDown;
                    @PointerDown.canceled -= m_Wrapper.m_LeftHandActionsCallbackInterface.OnPointerDown;
                    @PointerUp.started -= m_Wrapper.m_LeftHandActionsCallbackInterface.OnPointerUp;
                    @PointerUp.performed -= m_Wrapper.m_LeftHandActionsCallbackInterface.OnPointerUp;
                    @PointerUp.canceled -= m_Wrapper.m_LeftHandActionsCallbackInterface.OnPointerUp;
                }
                m_Wrapper.m_LeftHandActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ToggleMenu.started += instance.OnToggleMenu;
                    @ToggleMenu.performed += instance.OnToggleMenu;
                    @ToggleMenu.canceled += instance.OnToggleMenu;
                    @PointerDown.started += instance.OnPointerDown;
                    @PointerDown.performed += instance.OnPointerDown;
                    @PointerDown.canceled += instance.OnPointerDown;
                    @PointerUp.started += instance.OnPointerUp;
                    @PointerUp.performed += instance.OnPointerUp;
                    @PointerUp.canceled += instance.OnPointerUp;
                }
            }
        }
        public LeftHandActions @LeftHand => new LeftHandActions(this);

        // RightHand
        private readonly InputActionMap m_RightHand;
        private IRightHandActions m_RightHandActionsCallbackInterface;
        private readonly InputAction m_RightHand_ToggleMenu;
        private readonly InputAction m_RightHand_PointerDown;
        private readonly InputAction m_RightHand_PointerUp;
        public struct RightHandActions
        {
            private @AppInput m_Wrapper;
            public RightHandActions(@AppInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @ToggleMenu => m_Wrapper.m_RightHand_ToggleMenu;
            public InputAction @PointerDown => m_Wrapper.m_RightHand_PointerDown;
            public InputAction @PointerUp => m_Wrapper.m_RightHand_PointerUp;
            public InputActionMap Get() { return m_Wrapper.m_RightHand; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RightHandActions set) { return set.Get(); }
            public void SetCallbacks(IRightHandActions instance)
            {
                if (m_Wrapper.m_RightHandActionsCallbackInterface != null)
                {
                    @ToggleMenu.started -= m_Wrapper.m_RightHandActionsCallbackInterface.OnToggleMenu;
                    @ToggleMenu.performed -= m_Wrapper.m_RightHandActionsCallbackInterface.OnToggleMenu;
                    @ToggleMenu.canceled -= m_Wrapper.m_RightHandActionsCallbackInterface.OnToggleMenu;
                    @PointerDown.started -= m_Wrapper.m_RightHandActionsCallbackInterface.OnPointerDown;
                    @PointerDown.performed -= m_Wrapper.m_RightHandActionsCallbackInterface.OnPointerDown;
                    @PointerDown.canceled -= m_Wrapper.m_RightHandActionsCallbackInterface.OnPointerDown;
                    @PointerUp.started -= m_Wrapper.m_RightHandActionsCallbackInterface.OnPointerUp;
                    @PointerUp.performed -= m_Wrapper.m_RightHandActionsCallbackInterface.OnPointerUp;
                    @PointerUp.canceled -= m_Wrapper.m_RightHandActionsCallbackInterface.OnPointerUp;
                }
                m_Wrapper.m_RightHandActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ToggleMenu.started += instance.OnToggleMenu;
                    @ToggleMenu.performed += instance.OnToggleMenu;
                    @ToggleMenu.canceled += instance.OnToggleMenu;
                    @PointerDown.started += instance.OnPointerDown;
                    @PointerDown.performed += instance.OnPointerDown;
                    @PointerDown.canceled += instance.OnPointerDown;
                    @PointerUp.started += instance.OnPointerUp;
                    @PointerUp.performed += instance.OnPointerUp;
                    @PointerUp.canceled += instance.OnPointerUp;
                }
            }
        }
        public RightHandActions @RightHand => new RightHandActions(this);
        private int m_GenericXRControllerSchemeIndex = -1;
        public InputControlScheme GenericXRControllerScheme
        {
            get
            {
                if (m_GenericXRControllerSchemeIndex == -1) m_GenericXRControllerSchemeIndex = asset.FindControlSchemeIndex("Generic XR Controller");
                return asset.controlSchemes[m_GenericXRControllerSchemeIndex];
            }
        }
        public interface ILeftHandActions
        {
            void OnToggleMenu(InputAction.CallbackContext context);
            void OnPointerDown(InputAction.CallbackContext context);
            void OnPointerUp(InputAction.CallbackContext context);
        }
        public interface IRightHandActions
        {
            void OnToggleMenu(InputAction.CallbackContext context);
            void OnPointerDown(InputAction.CallbackContext context);
            void OnPointerUp(InputAction.CallbackContext context);
        }
    }
}
