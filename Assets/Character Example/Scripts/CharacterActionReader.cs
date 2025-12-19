using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachines.CharacterExample
{
    [Serializable]
    public class CharacterActionReader
    {
        [SerializeField] InputSystem_Actions _input;
        [field: SerializeField] public Vector2 MoveAction { get; private set; }
        [field: SerializeField] public bool JumpAction { get; private set; }
        [field: SerializeField] public bool RollAction { get; private set; }

        public void OnEnable()
        {
            _input = new InputSystem_Actions();
            _input.Enable();

            _input.Player.Crouch.performed  += OnCrouchPerformed;
            _input.Player.Crouch.canceled   += OnCrouchCanceled;
        }

        void OnCrouchPerformed(InputAction.CallbackContext context)
        {
            RollAction = true;
        }

        void OnCrouchCanceled(InputAction.CallbackContext context)
        {
            RollAction = false;
        }

        public void OnUpdate()
        {
            MoveAction = _input.Player.Move.ReadValue<Vector2>();
            JumpAction = _input.Player.Jump.WasPressedThisFrame();
        }

        public void OnDisable()
        {
            _input.Player.Crouch.performed  -= OnCrouchPerformed;
            _input.Player.Crouch.canceled   -= OnCrouchCanceled;

            _input.Disable();
        }

    } // End of Class
}
