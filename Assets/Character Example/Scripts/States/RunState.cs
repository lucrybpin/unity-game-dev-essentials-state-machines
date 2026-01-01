using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class RunState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        
        public RunState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.Play("Run");
        }
        
        public void Execute()
        {
            // -> FALL
            if (!_owner.Movement.IsGrounded)
            {
                StateMachine.ChangeState(CharacterState.FALL.ToString());
                return;
            }

            // -> IDLE
            if (_owner.ActionReader.MoveAction.x == 0)
            {
                StateMachine.ChangeState(CharacterState.IDLE.ToString());
                return;
            }

            // -> WALK
            if (!_owner.ActionReader.RunAction
                && _owner.ActionReader.MoveAction.x != 0)
            {
                StateMachine.ChangeState(CharacterState.IDLE.ToString());
                return;
            }

            _owner.Movement.SetVelocity(
                x: _owner.Movement.RunSpeed * _owner.ActionReader.MoveAction.x
            );
        }
        
        public void Exit()
        {
            
        }
    }
}