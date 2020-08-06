// GENERATED AUTOMATICALLY FROM 'Assets/Input Master.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input Master"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""76cf7c4e-fd6b-45d9-b8ce-d2bceefbc75d"",
            ""actions"": [
                {
                    ""name"": ""Rewind"",
                    ""type"": ""Button"",
                    ""id"": ""c897de0d-0032-4a50-b116-77fb34f6aa45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9aa5f890-acf2-40dc-8bf4-631e8f0a1e96"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rewind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Triggers"",
            ""id"": ""7f49276b-f628-4842-b036-d17fbbc0205e"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""7d133fd5-e462-49e4-8fc3-7580ab76063b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""25dec1e2-3896-4de7-888f-2dfbfda5cd48"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Rewind = m_Player.FindAction("Rewind", throwIfNotFound: true);
        // Triggers
        m_Triggers = asset.FindActionMap("Triggers", throwIfNotFound: true);
        m_Triggers_Rotate = m_Triggers.FindAction("Rotate", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Rewind;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rewind => m_Wrapper.m_Player_Rewind;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Rewind.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRewind;
                @Rewind.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRewind;
                @Rewind.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRewind;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rewind.started += instance.OnRewind;
                @Rewind.performed += instance.OnRewind;
                @Rewind.canceled += instance.OnRewind;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Triggers
    private readonly InputActionMap m_Triggers;
    private ITriggersActions m_TriggersActionsCallbackInterface;
    private readonly InputAction m_Triggers_Rotate;
    public struct TriggersActions
    {
        private @InputMaster m_Wrapper;
        public TriggersActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Triggers_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Triggers; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TriggersActions set) { return set.Get(); }
        public void SetCallbacks(ITriggersActions instance)
        {
            if (m_Wrapper.m_TriggersActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_TriggersActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_TriggersActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_TriggersActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_TriggersActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public TriggersActions @Triggers => new TriggersActions(this);
    public interface IPlayerActions
    {
        void OnRewind(InputAction.CallbackContext context);
    }
    public interface ITriggersActions
    {
        void OnRotate(InputAction.CallbackContext context);
    }
}
