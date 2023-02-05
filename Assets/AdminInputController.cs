//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/AdminInputController.inputactions
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

public partial class @AdminInputController : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @AdminInputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AdminInputController"",
    ""maps"": [
        {
            ""name"": ""Admin"",
            ""id"": ""54b17468-ed9a-48ec-9947-27538eed481e"",
            ""actions"": [
                {
                    ""name"": ""Skip"",
                    ""type"": ""Button"",
                    ""id"": ""a45eb8b7-d31a-41c7-b86f-ad909da246fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8e174985-bcc6-44e3-8354-1a7f51985315"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Admin
        m_Admin = asset.FindActionMap("Admin", throwIfNotFound: true);
        m_Admin_Skip = m_Admin.FindAction("Skip", throwIfNotFound: true);
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

    // Admin
    private readonly InputActionMap m_Admin;
    private IAdminActions m_AdminActionsCallbackInterface;
    private readonly InputAction m_Admin_Skip;
    public struct AdminActions
    {
        private @AdminInputController m_Wrapper;
        public AdminActions(@AdminInputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Skip => m_Wrapper.m_Admin_Skip;
        public InputActionMap Get() { return m_Wrapper.m_Admin; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AdminActions set) { return set.Get(); }
        public void SetCallbacks(IAdminActions instance)
        {
            if (m_Wrapper.m_AdminActionsCallbackInterface != null)
            {
                @Skip.started -= m_Wrapper.m_AdminActionsCallbackInterface.OnSkip;
                @Skip.performed -= m_Wrapper.m_AdminActionsCallbackInterface.OnSkip;
                @Skip.canceled -= m_Wrapper.m_AdminActionsCallbackInterface.OnSkip;
            }
            m_Wrapper.m_AdminActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Skip.started += instance.OnSkip;
                @Skip.performed += instance.OnSkip;
                @Skip.canceled += instance.OnSkip;
            }
        }
    }
    public AdminActions @Admin => new AdminActions(this);
    public interface IAdminActions
    {
        void OnSkip(InputAction.CallbackContext context);
    }
}