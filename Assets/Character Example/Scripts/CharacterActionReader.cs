using System;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    [Serializable]
    public class CharacterActionReader
    {
        [SerializeField] InputSystem_Actions _input;
        [field: SerializeField] public Vector2 MoveAction { get; private set; }

        public void OnEnable()
        {
            _input = new InputSystem_Actions();
            _input.Enable();
        }


        public void OnUpdate()
        {
            MoveAction = _input.Player.Move.ReadValue<Vector2>();
        }

        public void OnDisable()
        {
            _input.Disable();
        }

    } // End of Class
}
