//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/InputSystem/PlayerInput.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""GameAction"",
            ""id"": ""dab94763-c8fa-4f82-bd94-235b05ce4cd4"",
            ""actions"": [
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""8e87025a-dc5e-4eb5-96d7-83fe004ee0d0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Value"",
                    ""id"": ""5bb7b7b7-f9a9-4be0-962c-c6d84fd8585d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SouthButton"",
                    ""type"": ""Button"",
                    ""id"": ""6c3448d7-d689-4b94-b832-968a1ba9cf8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WestButton"",
                    ""type"": ""Button"",
                    ""id"": ""34e7ff3c-f072-4b11-9bfe-8518f734e068"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NorthButton"",
                    ""type"": ""Button"",
                    ""id"": ""27d9204e-982b-4d9b-9a6f-525949578709"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EastButton"",
                    ""type"": ""Button"",
                    ""id"": ""6a8e9d16-7d40-4883-98ca-b16cb3be23d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightShoulder"",
                    ""type"": ""Button"",
                    ""id"": ""9c8bd70b-4198-47ed-8209-a08048b14276"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftShoulder"",
                    ""type"": ""Button"",
                    ""id"": ""e177e9e8-92dc-44da-9806-0cb72e88806b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""142dc7a3-9de0-458f-9b6f-c4974c2b84cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""54a909d7-1e48-4fbd-a381-699652140bed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DPad"",
                    ""type"": ""Value"",
                    ""id"": ""21275a06-33d6-437f-b8b8-eff028901671"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""414a41f7-b5fc-4a94-9e29-f0f5946f2984"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""c7ea9b4e-5fb2-49a1-bb2d-f58a642555ff"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c8c39c28-2e27-4ca8-96f7-77bbf1f71e00"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ca915f86-fb51-410f-b3c7-cb945edfa56b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""419a33f0-4f4d-4403-8686-5f360c2e492a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0a75ad0e-db48-4d9a-b6e6-20941b122ff7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""21226b1c-aca5-4749-bd43-8dac931d9f08"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""78fdb491-4e88-42d6-a1ef-a9f82869f33a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""84df23d2-e49e-4a04-8bf3-5852b9b92561"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b2e517fa-b9aa-4179-be31-29190a35c79b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9edf8f44-f6b2-476e-9679-c96471205849"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""095db455-1fe8-4181-b773-21ceb6e3361e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7946b07d-bca8-49aa-9056-d62c2b392004"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aed99cec-9f41-4920-966d-1eb67dcd9fc7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""090b41ed-f70e-4c3c-b4e5-ee3fef323b87"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fc8289c-9a64-4d08-8b30-78b4c149a615"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b7dc084-8195-4fe1-adde-6d22b03491da"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b02598a-0313-43c9-9cf9-ba7bfdce1b30"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aab6bc7e-52d8-488e-a98a-bb71cce2b2b7"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2180408-56e6-4cde-898a-b38e83db4ca5"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b44e58ef-e4ad-46ab-af55-0a179b453b57"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb3cc89c-cb26-4237-9a33-4a3bdb417285"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99e8a5b2-046f-4453-b280-7db0a50afe1e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""32166007-8105-431e-b77e-a5b52edd6681"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ca48950d-0cf9-4fac-ba4d-ac8c2fd52ecf"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4fdeae2b-6374-445e-8f38-4073fd1e5d4d"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5f1773e3-6b04-4e60-9431-a77193046b5e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bf354435-1c63-4e2f-a203-772107637873"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UIAction"",
            ""id"": ""8b26bc07-dc9c-424c-8f63-98e9ca2ce31f"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""f35dc037-f58e-4613-aac9-8e23b910257b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bc9531a2-a2da-44c0-b812-e74b64c55d41"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameAction
        m_GameAction = asset.FindActionMap("GameAction", throwIfNotFound: true);
        m_GameAction_LeftStick = m_GameAction.FindAction("LeftStick", throwIfNotFound: true);
        m_GameAction_RightStick = m_GameAction.FindAction("RightStick", throwIfNotFound: true);
        m_GameAction_SouthButton = m_GameAction.FindAction("SouthButton", throwIfNotFound: true);
        m_GameAction_WestButton = m_GameAction.FindAction("WestButton", throwIfNotFound: true);
        m_GameAction_NorthButton = m_GameAction.FindAction("NorthButton", throwIfNotFound: true);
        m_GameAction_EastButton = m_GameAction.FindAction("EastButton", throwIfNotFound: true);
        m_GameAction_RightShoulder = m_GameAction.FindAction("RightShoulder", throwIfNotFound: true);
        m_GameAction_LeftShoulder = m_GameAction.FindAction("LeftShoulder", throwIfNotFound: true);
        m_GameAction_RightTrigger = m_GameAction.FindAction("RightTrigger", throwIfNotFound: true);
        m_GameAction_LeftTrigger = m_GameAction.FindAction("LeftTrigger", throwIfNotFound: true);
        m_GameAction_DPad = m_GameAction.FindAction("DPad", throwIfNotFound: true);
        // UIAction
        m_UIAction = asset.FindActionMap("UIAction", throwIfNotFound: true);
        m_UIAction_Newaction = m_UIAction.FindAction("New action", throwIfNotFound: true);
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

    // GameAction
    private readonly InputActionMap m_GameAction;
    private IGameActionActions m_GameActionActionsCallbackInterface;
    private readonly InputAction m_GameAction_LeftStick;
    private readonly InputAction m_GameAction_RightStick;
    private readonly InputAction m_GameAction_SouthButton;
    private readonly InputAction m_GameAction_WestButton;
    private readonly InputAction m_GameAction_NorthButton;
    private readonly InputAction m_GameAction_EastButton;
    private readonly InputAction m_GameAction_RightShoulder;
    private readonly InputAction m_GameAction_LeftShoulder;
    private readonly InputAction m_GameAction_RightTrigger;
    private readonly InputAction m_GameAction_LeftTrigger;
    private readonly InputAction m_GameAction_DPad;
    public struct GameActionActions
    {
        private @PlayerInput m_Wrapper;
        public GameActionActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStick => m_Wrapper.m_GameAction_LeftStick;
        public InputAction @RightStick => m_Wrapper.m_GameAction_RightStick;
        public InputAction @SouthButton => m_Wrapper.m_GameAction_SouthButton;
        public InputAction @WestButton => m_Wrapper.m_GameAction_WestButton;
        public InputAction @NorthButton => m_Wrapper.m_GameAction_NorthButton;
        public InputAction @EastButton => m_Wrapper.m_GameAction_EastButton;
        public InputAction @RightShoulder => m_Wrapper.m_GameAction_RightShoulder;
        public InputAction @LeftShoulder => m_Wrapper.m_GameAction_LeftShoulder;
        public InputAction @RightTrigger => m_Wrapper.m_GameAction_RightTrigger;
        public InputAction @LeftTrigger => m_Wrapper.m_GameAction_LeftTrigger;
        public InputAction @DPad => m_Wrapper.m_GameAction_DPad;
        public InputActionMap Get() { return m_Wrapper.m_GameAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActionActions set) { return set.Get(); }
        public void SetCallbacks(IGameActionActions instance)
        {
            if (m_Wrapper.m_GameActionActionsCallbackInterface != null)
            {
                @LeftStick.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnLeftStick;
                @RightStick.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnRightStick;
                @SouthButton.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnSouthButton;
                @SouthButton.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnSouthButton;
                @SouthButton.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnSouthButton;
                @WestButton.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnWestButton;
                @WestButton.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnWestButton;
                @WestButton.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnWestButton;
                @NorthButton.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnNorthButton;
                @NorthButton.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnNorthButton;
                @NorthButton.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnNorthButton;
                @EastButton.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnEastButton;
                @EastButton.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnEastButton;
                @EastButton.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnEastButton;
                @RightShoulder.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnRightShoulder;
                @RightShoulder.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnRightShoulder;
                @RightShoulder.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnRightShoulder;
                @LeftShoulder.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnLeftShoulder;
                @LeftShoulder.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnLeftShoulder;
                @LeftShoulder.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnLeftShoulder;
                @RightTrigger.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnRightTrigger;
                @LeftTrigger.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnLeftTrigger;
                @DPad.started -= m_Wrapper.m_GameActionActionsCallbackInterface.OnDPad;
                @DPad.performed -= m_Wrapper.m_GameActionActionsCallbackInterface.OnDPad;
                @DPad.canceled -= m_Wrapper.m_GameActionActionsCallbackInterface.OnDPad;
            }
            m_Wrapper.m_GameActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
                @SouthButton.started += instance.OnSouthButton;
                @SouthButton.performed += instance.OnSouthButton;
                @SouthButton.canceled += instance.OnSouthButton;
                @WestButton.started += instance.OnWestButton;
                @WestButton.performed += instance.OnWestButton;
                @WestButton.canceled += instance.OnWestButton;
                @NorthButton.started += instance.OnNorthButton;
                @NorthButton.performed += instance.OnNorthButton;
                @NorthButton.canceled += instance.OnNorthButton;
                @EastButton.started += instance.OnEastButton;
                @EastButton.performed += instance.OnEastButton;
                @EastButton.canceled += instance.OnEastButton;
                @RightShoulder.started += instance.OnRightShoulder;
                @RightShoulder.performed += instance.OnRightShoulder;
                @RightShoulder.canceled += instance.OnRightShoulder;
                @LeftShoulder.started += instance.OnLeftShoulder;
                @LeftShoulder.performed += instance.OnLeftShoulder;
                @LeftShoulder.canceled += instance.OnLeftShoulder;
                @RightTrigger.started += instance.OnRightTrigger;
                @RightTrigger.performed += instance.OnRightTrigger;
                @RightTrigger.canceled += instance.OnRightTrigger;
                @LeftTrigger.started += instance.OnLeftTrigger;
                @LeftTrigger.performed += instance.OnLeftTrigger;
                @LeftTrigger.canceled += instance.OnLeftTrigger;
                @DPad.started += instance.OnDPad;
                @DPad.performed += instance.OnDPad;
                @DPad.canceled += instance.OnDPad;
            }
        }
    }
    public GameActionActions @GameAction => new GameActionActions(this);

    // UIAction
    private readonly InputActionMap m_UIAction;
    private IUIActionActions m_UIActionActionsCallbackInterface;
    private readonly InputAction m_UIAction_Newaction;
    public struct UIActionActions
    {
        private @PlayerInput m_Wrapper;
        public UIActionActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UIAction_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UIAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActionActions set) { return set.Get(); }
        public void SetCallbacks(IUIActionActions instance)
        {
            if (m_Wrapper.m_UIActionActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_UIActionActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_UIActionActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_UIActionActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UIActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UIActionActions @UIAction => new UIActionActions(this);
    public interface IGameActionActions
    {
        void OnLeftStick(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
        void OnSouthButton(InputAction.CallbackContext context);
        void OnWestButton(InputAction.CallbackContext context);
        void OnNorthButton(InputAction.CallbackContext context);
        void OnEastButton(InputAction.CallbackContext context);
        void OnRightShoulder(InputAction.CallbackContext context);
        void OnLeftShoulder(InputAction.CallbackContext context);
        void OnRightTrigger(InputAction.CallbackContext context);
        void OnLeftTrigger(InputAction.CallbackContext context);
        void OnDPad(InputAction.CallbackContext context);
    }
    public interface IUIActionActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
