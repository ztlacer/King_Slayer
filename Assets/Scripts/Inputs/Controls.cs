// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""164ee62f-831b-49cd-8dd0-90af398014dd"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""30353598-8503-40d7-bc9b-9dcfe0c82343"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4d1d5651-4ae8-4a7c-ac86-988113e83144"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sneak"",
                    ""type"": ""Button"",
                    ""id"": ""89864b2c-ee6c-45f7-a034-4ae3fdb5b2d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""cd9c2896-c1a7-4b00-926e-0a3f1bb980e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""0b69ca0d-498c-4a57-ac75-a697339d9148"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartPuzzle"",
                    ""type"": ""Button"",
                    ""id"": ""d61ff820-3bde-4dd6-8c88-a1950ad71a78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectInPuzzle"",
                    ""type"": ""Button"",
                    ""id"": ""05c719f6-fab9-488c-90b3-6bd836e4e18a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenInventory"",
                    ""type"": ""Button"",
                    ""id"": ""ad87b176-7ecf-4c13-90f9-876b658ed8e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenShop"",
                    ""type"": ""Button"",
                    ""id"": ""a31a85aa-cda9-4217-a883-8d129e9a0c6b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectMoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""c8104fbb-54a5-43b8-9469-89d29a8688ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectMoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""3476986d-1ae2-4f5c-8e48-a4de1c89b176"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectMoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""6d65fa9c-341a-4796-86df-87f63ba000eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectMoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""76f6813e-0621-4d63-8b17-17fb2b904bdb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Buy"",
                    ""type"": ""Button"",
                    ""id"": ""33e34c96-d912-469e-a6e6-2581a60195c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PuzzleMouse"",
                    ""type"": ""Value"",
                    ""id"": ""d59a6a7c-924d-4c10-abb4-a888632dac0b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9838163d-50f0-49e8-ac0b-9687e9e6c684"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse;GameController"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5799dd4d-1a41-466d-b3d4-527c5d695b15"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""88e27261-b694-4299-85e1-42c0e9b49d40"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1c7511b5-c741-42cc-9321-0e4d54438790"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d486e89f-7849-46d8-a9f7-ce2aa1b003c0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3982715a-eda9-430a-b9de-79f97541ac07"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d291fa49-6332-4972-ba47-e5690b3fc111"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3015ac26-8f43-4c8a-9abd-4d020b1998da"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64967a16-4455-4198-b810-4693c6327188"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Sneak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cb90b4a-27e4-47ee-a1cc-606e65c0e3e2"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""Sneak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b28eb749-5a5a-4329-86ac-2f167606c753"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a086d2ab-4e93-4ed3-b8f2-5bdb4bbd7211"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6aa0f86-65df-4815-9c76-7bca11fad0c9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3318306c-b155-4542-b628-d1b39179a34b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cd573e5-9483-42d5-b0a6-c0887829fda4"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""StartPuzzle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""206ad150-18aa-49a4-8b9c-3c9a5d9b1581"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""StartPuzzle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c98b649-d121-4fdb-87ec-f17e1acc3136"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""SelectInPuzzle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29260b34-4f13-445f-80aa-b3271ed4ce41"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""OpenInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c98d62ac-4356-4540-a544-bb2156d24582"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""OpenInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b086ef5-c8f3-4524-9f02-298a78b31ea9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""OpenShop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e4aafc6-f385-439e-987f-8dc18247c3ff"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""OpenShop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04b13bb5-37cb-4110-b29b-c525d67e9d21"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""SelectMoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83c1b605-5de0-4d95-9ef1-de87c78d6a68"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""SelectMoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e9ec5f0-a3ee-4b23-b46c-e74e7a6304a4"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""SelectMoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c548157d-a7ce-4242-8792-195b8a1db4da"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""SelectMoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7edccb5-5800-4894-a9cc-d1ae90ef8ee8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""SelectMoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cf03ca8-cbd4-4176-b3cf-ff6c543b1cdd"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""SelectMoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e6516fb-05cb-44d3-8eb5-94faab03c18e"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""SelectMoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73b58ce2-66b5-42a6-93a6-347080cba1c2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""SelectMoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d83dcaf-a618-4e58-b1f4-fb226200cbd1"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Buy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c6a2ddd-b54a-4dce-ad35-a3b981c21454"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""Buy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcbe9089-24ab-462f-95f9-e25b18405cd4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameController"",
                    ""action"": ""PuzzleMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GameController"",
            ""bindingGroup"": ""GameController"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Sneak = m_Player.FindAction("Sneak", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_StartPuzzle = m_Player.FindAction("StartPuzzle", throwIfNotFound: true);
        m_Player_SelectInPuzzle = m_Player.FindAction("SelectInPuzzle", throwIfNotFound: true);
        m_Player_OpenInventory = m_Player.FindAction("OpenInventory", throwIfNotFound: true);
        m_Player_OpenShop = m_Player.FindAction("OpenShop", throwIfNotFound: true);
        m_Player_SelectMoveLeft = m_Player.FindAction("SelectMoveLeft", throwIfNotFound: true);
        m_Player_SelectMoveRight = m_Player.FindAction("SelectMoveRight", throwIfNotFound: true);
        m_Player_SelectMoveUp = m_Player.FindAction("SelectMoveUp", throwIfNotFound: true);
        m_Player_SelectMoveDown = m_Player.FindAction("SelectMoveDown", throwIfNotFound: true);
        m_Player_Buy = m_Player.FindAction("Buy", throwIfNotFound: true);
        m_Player_PuzzleMouse = m_Player.FindAction("PuzzleMouse", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Sneak;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_StartPuzzle;
    private readonly InputAction m_Player_SelectInPuzzle;
    private readonly InputAction m_Player_OpenInventory;
    private readonly InputAction m_Player_OpenShop;
    private readonly InputAction m_Player_SelectMoveLeft;
    private readonly InputAction m_Player_SelectMoveRight;
    private readonly InputAction m_Player_SelectMoveUp;
    private readonly InputAction m_Player_SelectMoveDown;
    private readonly InputAction m_Player_Buy;
    private readonly InputAction m_Player_PuzzleMouse;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Sneak => m_Wrapper.m_Player_Sneak;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @StartPuzzle => m_Wrapper.m_Player_StartPuzzle;
        public InputAction @SelectInPuzzle => m_Wrapper.m_Player_SelectInPuzzle;
        public InputAction @OpenInventory => m_Wrapper.m_Player_OpenInventory;
        public InputAction @OpenShop => m_Wrapper.m_Player_OpenShop;
        public InputAction @SelectMoveLeft => m_Wrapper.m_Player_SelectMoveLeft;
        public InputAction @SelectMoveRight => m_Wrapper.m_Player_SelectMoveRight;
        public InputAction @SelectMoveUp => m_Wrapper.m_Player_SelectMoveUp;
        public InputAction @SelectMoveDown => m_Wrapper.m_Player_SelectMoveDown;
        public InputAction @Buy => m_Wrapper.m_Player_Buy;
        public InputAction @PuzzleMouse => m_Wrapper.m_Player_PuzzleMouse;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Sneak.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSneak;
                @Sneak.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSneak;
                @Sneak.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSneak;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @StartPuzzle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartPuzzle;
                @StartPuzzle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartPuzzle;
                @StartPuzzle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartPuzzle;
                @SelectInPuzzle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectInPuzzle;
                @SelectInPuzzle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectInPuzzle;
                @SelectInPuzzle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectInPuzzle;
                @OpenInventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @OpenShop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenShop;
                @OpenShop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenShop;
                @OpenShop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenShop;
                @SelectMoveLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveLeft;
                @SelectMoveLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveLeft;
                @SelectMoveLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveLeft;
                @SelectMoveRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveRight;
                @SelectMoveRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveRight;
                @SelectMoveRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveRight;
                @SelectMoveUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveUp;
                @SelectMoveUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveUp;
                @SelectMoveUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveUp;
                @SelectMoveDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveDown;
                @SelectMoveDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveDown;
                @SelectMoveDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMoveDown;
                @Buy.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBuy;
                @Buy.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBuy;
                @Buy.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBuy;
                @PuzzleMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPuzzleMouse;
                @PuzzleMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPuzzleMouse;
                @PuzzleMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPuzzleMouse;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Sneak.started += instance.OnSneak;
                @Sneak.performed += instance.OnSneak;
                @Sneak.canceled += instance.OnSneak;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @StartPuzzle.started += instance.OnStartPuzzle;
                @StartPuzzle.performed += instance.OnStartPuzzle;
                @StartPuzzle.canceled += instance.OnStartPuzzle;
                @SelectInPuzzle.started += instance.OnSelectInPuzzle;
                @SelectInPuzzle.performed += instance.OnSelectInPuzzle;
                @SelectInPuzzle.canceled += instance.OnSelectInPuzzle;
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
                @OpenShop.started += instance.OnOpenShop;
                @OpenShop.performed += instance.OnOpenShop;
                @OpenShop.canceled += instance.OnOpenShop;
                @SelectMoveLeft.started += instance.OnSelectMoveLeft;
                @SelectMoveLeft.performed += instance.OnSelectMoveLeft;
                @SelectMoveLeft.canceled += instance.OnSelectMoveLeft;
                @SelectMoveRight.started += instance.OnSelectMoveRight;
                @SelectMoveRight.performed += instance.OnSelectMoveRight;
                @SelectMoveRight.canceled += instance.OnSelectMoveRight;
                @SelectMoveUp.started += instance.OnSelectMoveUp;
                @SelectMoveUp.performed += instance.OnSelectMoveUp;
                @SelectMoveUp.canceled += instance.OnSelectMoveUp;
                @SelectMoveDown.started += instance.OnSelectMoveDown;
                @SelectMoveDown.performed += instance.OnSelectMoveDown;
                @SelectMoveDown.canceled += instance.OnSelectMoveDown;
                @Buy.started += instance.OnBuy;
                @Buy.performed += instance.OnBuy;
                @Buy.canceled += instance.OnBuy;
                @PuzzleMouse.started += instance.OnPuzzleMouse;
                @PuzzleMouse.performed += instance.OnPuzzleMouse;
                @PuzzleMouse.canceled += instance.OnPuzzleMouse;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GameControllerSchemeIndex = -1;
    public InputControlScheme GameControllerScheme
    {
        get
        {
            if (m_GameControllerSchemeIndex == -1) m_GameControllerSchemeIndex = asset.FindControlSchemeIndex("GameController");
            return asset.controlSchemes[m_GameControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnLook(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnSneak(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnStartPuzzle(InputAction.CallbackContext context);
        void OnSelectInPuzzle(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
        void OnOpenShop(InputAction.CallbackContext context);
        void OnSelectMoveLeft(InputAction.CallbackContext context);
        void OnSelectMoveRight(InputAction.CallbackContext context);
        void OnSelectMoveUp(InputAction.CallbackContext context);
        void OnSelectMoveDown(InputAction.CallbackContext context);
        void OnBuy(InputAction.CallbackContext context);
        void OnPuzzleMouse(InputAction.CallbackContext context);
    }
}
