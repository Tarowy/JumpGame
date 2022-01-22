// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""JumpGame"",
            ""id"": ""f2868c51-83f8-4c71-a754-d0e08d176a03"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""22ceec82-51a0-4673-bb83-b1aaddea0d36"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""3c1e3a8c-10e6-4984-abe7-ebda268c8b4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f58607b9-ca75-4cc5-bcf0-9c46b9ad324e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""02daf7a8-bb99-459d-a83e-19581110af05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""999318d1-b2aa-4733-b356-81745538597a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bomb"",
                    ""type"": ""Button"",
                    ""id"": ""4d9af7ef-c233-46b8-870f-2a2631cd912d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeImage"",
                    ""type"": ""Button"",
                    ""id"": ""f78924ba-88ac-452e-b652-808f5851921e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c85e9e90-ddd5-40ca-b9dc-ead02ac3aac9"",
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
                    ""id"": ""a4b33a02-7481-4861-81d8-8e9f3c8d7b13"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a25730ed-1112-44dc-8eb7-b24d66ff13b0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b5d114c9-16f2-4968-a475-71a8c8d7fb2e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fcdd000a-b1e2-49d7-8754-d890bb72f1a8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""e5af9ec1-f28c-40e8-ab8d-b5bbbb145f15"",
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
                    ""id"": ""a150a0c2-91ba-409c-a556-589ba132f349"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5e298a89-368c-46fd-9559-d21ffeee9b2c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e4ce488d-ffd6-4c41-a214-d461d182cd4d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""21a8444a-1a81-4fbb-9442-da11df1607e7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""4c1d241e-9dd7-481a-8fab-96c9bdd142a6"",
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
                    ""id"": ""eaaec13a-b13a-43b7-baca-1cf24701d1b1"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""637bd7ab-574a-4a86-a6e6-c72a908ca7ed"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7e363c7a-b62d-4cbf-997f-7d2a37962f2c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""22f716c3-2a30-4564-bc33-c4cb4fa03cee"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""a2275f62-e483-4376-8678-a183082c7524"",
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
                    ""id"": ""f2c3874a-c674-4f71-b068-425feee00d74"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bf566bd2-82dd-44a3-8289-e4eb6cd2d8d4"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0c00e82f-7cef-49a6-9a23-6b9a26b16d2f"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3d0c90d0-a5aa-407c-8835-6ad8a48973ae"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9ab81ba4-252f-4f34-bd62-3e7bfb06ee12"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eafdc580-e908-4f40-8c20-6b69c145a8ae"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d858897-13fb-44c2-b0d8-654e26d61157"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""008328d6-d8d8-4476-a7a1-def858a28d97"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07fb6ea9-f038-4911-8393-5d231b117d1a"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b20cd32-3f73-44dd-856d-6aebef228b22"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c185062f-0e6e-441c-bc78-f75f0a32dfeb"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a62ff7b1-7505-4696-92f2-6172bb65f008"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5313d7f5-6da6-4850-940a-a676260fb1b4"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Bomb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f08822c-c787-4e0f-87dc-796f27c44c06"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Bomb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9db910de-1555-4441-9f8d-0142c2529cb0"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""ChangeImage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4998e2d4-3f65-44d7-87d4-783a537bb368"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ChangeImage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Xbox"",
            ""bindingGroup"": ""Xbox"",
            ""devices"": []
        }
    ]
}");
        // JumpGame
        m_JumpGame = asset.FindActionMap("JumpGame", throwIfNotFound: true);
        m_JumpGame_Move = m_JumpGame.FindAction("Move", throwIfNotFound: true);
        m_JumpGame_Attack = m_JumpGame.FindAction("Attack", throwIfNotFound: true);
        m_JumpGame_Jump = m_JumpGame.FindAction("Jump", throwIfNotFound: true);
        m_JumpGame_Pause = m_JumpGame.FindAction("Pause", throwIfNotFound: true);
        m_JumpGame_Throw = m_JumpGame.FindAction("Throw", throwIfNotFound: true);
        m_JumpGame_Bomb = m_JumpGame.FindAction("Bomb", throwIfNotFound: true);
        m_JumpGame_ChangeImage = m_JumpGame.FindAction("ChangeImage", throwIfNotFound: true);
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

    // JumpGame
    private readonly InputActionMap m_JumpGame;
    private IJumpGameActions m_JumpGameActionsCallbackInterface;
    private readonly InputAction m_JumpGame_Move;
    private readonly InputAction m_JumpGame_Attack;
    private readonly InputAction m_JumpGame_Jump;
    private readonly InputAction m_JumpGame_Pause;
    private readonly InputAction m_JumpGame_Throw;
    private readonly InputAction m_JumpGame_Bomb;
    private readonly InputAction m_JumpGame_ChangeImage;
    public struct JumpGameActions
    {
        private @InputSystem m_Wrapper;
        public JumpGameActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_JumpGame_Move;
        public InputAction @Attack => m_Wrapper.m_JumpGame_Attack;
        public InputAction @Jump => m_Wrapper.m_JumpGame_Jump;
        public InputAction @Pause => m_Wrapper.m_JumpGame_Pause;
        public InputAction @Throw => m_Wrapper.m_JumpGame_Throw;
        public InputAction @Bomb => m_Wrapper.m_JumpGame_Bomb;
        public InputAction @ChangeImage => m_Wrapper.m_JumpGame_ChangeImage;
        public InputActionMap Get() { return m_Wrapper.m_JumpGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JumpGameActions set) { return set.Get(); }
        public void SetCallbacks(IJumpGameActions instance)
        {
            if (m_Wrapper.m_JumpGameActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnAttack;
                @Jump.started -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnJump;
                @Pause.started -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnPause;
                @Throw.started -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnThrow;
                @Bomb.started -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnBomb;
                @Bomb.performed -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnBomb;
                @Bomb.canceled -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnBomb;
                @ChangeImage.started -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnChangeImage;
                @ChangeImage.performed -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnChangeImage;
                @ChangeImage.canceled -= m_Wrapper.m_JumpGameActionsCallbackInterface.OnChangeImage;
            }
            m_Wrapper.m_JumpGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @Bomb.started += instance.OnBomb;
                @Bomb.performed += instance.OnBomb;
                @Bomb.canceled += instance.OnBomb;
                @ChangeImage.started += instance.OnChangeImage;
                @ChangeImage.performed += instance.OnChangeImage;
                @ChangeImage.canceled += instance.OnChangeImage;
            }
        }
    }
    public JumpGameActions @JumpGame => new JumpGameActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_XboxSchemeIndex = -1;
    public InputControlScheme XboxScheme
    {
        get
        {
            if (m_XboxSchemeIndex == -1) m_XboxSchemeIndex = asset.FindControlSchemeIndex("Xbox");
            return asset.controlSchemes[m_XboxSchemeIndex];
        }
    }
    public interface IJumpGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnBomb(InputAction.CallbackContext context);
        void OnChangeImage(InputAction.CallbackContext context);
    }
}
