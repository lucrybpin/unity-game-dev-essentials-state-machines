using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class WalkState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        
        public WalkState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.Play("Walk");
        }
        
        public void Execute()
        {
            // -> IDLE
            if (_owner.ActionReader.MoveAction.x == 0)
            {
                StateMachine.ChangeState(CharacterState.IDLE.ToString());
                return;
            }

            // -> JUMP
            if (_owner.ActionReader.JumpAction)
            {
                StateMachine.ChangeState(CharacterState.JUMP.ToString());
                return;
            }

            _owner.Movement.SetVelocity(
                x: _owner.Movement.WalkSpeed * _owner.ActionReader.MoveAction.x
            );
        }
        
        public void Exit()
        {
            
        }

    } // End of Class
}