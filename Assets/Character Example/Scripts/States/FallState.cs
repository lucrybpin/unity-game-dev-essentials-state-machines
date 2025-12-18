using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class FallState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        
        public FallState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.Play("Fall");
        }
        
        public void Execute()
        {
            // -> IDLE
            if (_owner.Movement.IsGrounded)
            {
                StateMachine.ChangeState(CharacterState.IDLE.ToString());
                return;
            }
        }
        
        public void Exit()
        {
            
        }
    }
}