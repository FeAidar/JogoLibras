// GENERATED AUTOMATICALLY FROM 'Assets/Resorces/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""5ccfb88f-abfa-4ba9-8fd3-83457780228f"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""918d1f73-3d9d-400b-8abb-0256690336de"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cda88e57-c0aa-4ee9-8d15-9003118cdf01"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bd0e091e-b157-4ea7-ad40-e829b50775ab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6666ffee-5a52-4d54-bf9c-5e6a11c6d55d"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11a2b4dc-30ad-43ae-a7de-21ee585cb26d"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f91aaf29-f973-45be-bd94-c665008b54ec"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inputs
        m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
        m_Inputs_Touch = m_Inputs.FindAction("Touch", throwIfNotFound: true);
        m_Inputs_TouchPress = m_Inputs.FindAction("TouchPress", throwIfNotFound: true);
        m_Inputs_TouchPosition = m_Inputs.FindAction("TouchPosition", throwIfNotFound: true);
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

    // Inputs
    private readonly InputActionMap m_Inputs;
    private IInputsActions m_InputsActionsCallbackInterface;
    private readonly InputAction m_Inputs_Touch;
    private readonly InputAction m_Inputs_TouchPress;
    private readonly InputAction m_Inputs_TouchPosition;
    public struct InputsActions
    {
        private @NewControls m_Wrapper;
        public InputsActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_Inputs_Touch;
        public InputAction @TouchPress => m_Wrapper.m_Inputs_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_Inputs_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Inputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
        public void SetCallbacks(IInputsActions instance)
        {
            if (m_Wrapper.m_InputsActionsCallbackInterface != null)
            {
                @Touch.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouch;
                @TouchPress.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPress;
                @TouchPosition.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPosition;
            }
            m_Wrapper.m_InputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
            }
        }
    }
    public InputsActions @Inputs => new InputsActions(this);
    public interface IInputsActions
    {
        void OnTouch(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
