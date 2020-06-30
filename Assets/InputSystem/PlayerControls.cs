// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""4359fa41-dc99-4bed-a1e9-6d49ca48d839"",
            ""actions"": [
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""feb6eb8f-6a2a-4ae1-b4d3-b76a8a9e7dc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimAxis"",
                    ""type"": ""Value"",
                    ""id"": ""f96bcfa9-50f6-42da-a79c-a5969510f588"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchCameras"",
                    ""type"": ""Button"",
                    ""id"": ""0fb83237-97fe-4ead-b4f6-21751c3a8414"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f535db83-ac3f-459a-b0dd-077a9039a8bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WASD"",
                    ""type"": ""PassThrough"",
                    ""id"": ""07e50f66-772f-45a5-b071-269020e4f4d7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""18225d25-323a-4c04-995c-9e5036486e1b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f41d552-dba7-4599-9ef9-f8a4266ea38b"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0632a8fa-c6aa-419a-9046-cbd366cbe9d8"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCameras"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8ba8c2b-c3ea-46c8-a0b0-4eed33c72576"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d039ea20-8c1f-4dcf-850e-11973acf08d5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""01f50233-a0bb-49e3-929b-d341489e926b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""55f4b5a1-6cd0-45ed-a3b1-754f678d6b21"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""52a2268b-d34e-4ea5-9c43-a97685a753aa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7dde783c-2cea-44e2-9654-971bfda1f8bb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlayerControlScheme"",
            ""bindingGroup"": ""PlayerControlScheme"",
            ""devices"": []
        }
    ]
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_RightClick = m_GamePlay.FindAction("RightClick", throwIfNotFound: true);
        m_GamePlay_AimAxis = m_GamePlay.FindAction("AimAxis", throwIfNotFound: true);
        m_GamePlay_SwitchCameras = m_GamePlay.FindAction("SwitchCameras", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_WASD = m_GamePlay.FindAction("WASD", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_RightClick;
    private readonly InputAction m_GamePlay_AimAxis;
    private readonly InputAction m_GamePlay_SwitchCameras;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_WASD;
    public struct GamePlayActions
    {
        private @PlayerControls m_Wrapper;
        public GamePlayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightClick => m_Wrapper.m_GamePlay_RightClick;
        public InputAction @AimAxis => m_Wrapper.m_GamePlay_AimAxis;
        public InputAction @SwitchCameras => m_Wrapper.m_GamePlay_SwitchCameras;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @WASD => m_Wrapper.m_GamePlay_WASD;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @RightClick.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRightClick;
                @AimAxis.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAimAxis;
                @AimAxis.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAimAxis;
                @AimAxis.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAimAxis;
                @SwitchCameras.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSwitchCameras;
                @SwitchCameras.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSwitchCameras;
                @SwitchCameras.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSwitchCameras;
                @Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @WASD.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnWASD;
                @WASD.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnWASD;
                @WASD.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnWASD;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @AimAxis.started += instance.OnAimAxis;
                @AimAxis.performed += instance.OnAimAxis;
                @AimAxis.canceled += instance.OnAimAxis;
                @SwitchCameras.started += instance.OnSwitchCameras;
                @SwitchCameras.performed += instance.OnSwitchCameras;
                @SwitchCameras.canceled += instance.OnSwitchCameras;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @WASD.started += instance.OnWASD;
                @WASD.performed += instance.OnWASD;
                @WASD.canceled += instance.OnWASD;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    private int m_PlayerControlSchemeSchemeIndex = -1;
    public InputControlScheme PlayerControlSchemeScheme
    {
        get
        {
            if (m_PlayerControlSchemeSchemeIndex == -1) m_PlayerControlSchemeSchemeIndex = asset.FindControlSchemeIndex("PlayerControlScheme");
            return asset.controlSchemes[m_PlayerControlSchemeSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnRightClick(InputAction.CallbackContext context);
        void OnAimAxis(InputAction.CallbackContext context);
        void OnSwitchCameras(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnWASD(InputAction.CallbackContext context);
    }
}
