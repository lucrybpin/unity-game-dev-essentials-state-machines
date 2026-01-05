using StateMachines.Obstacles;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class IdleState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        
        public IdleState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.Play("Idle");
            _owner.Movement.SetVelocity(x: 0);
        }
        
        public void Execute()
        {
            // -> FALL
            if (!_owner.Movement.IsGrounded)
            {
                StateMachine.ChangeState(CharacterState.FALL.ToString());
                return;
            }

            // -> CLIMB
            if (_owner.Sensor.SensorData.Climbable != null
                && _owner.ActionReader.MoveAction.y != 0)
            {
                StateMachine.ChangeState(CharacterState.CLIMB.ToString());
                return;
            }

            // -> CROUCH
            if (_owner.ActionReader.MoveAction.y < 0)
            {
                StateMachine.ChangeState(CharacterState.CROUCH.ToString());
                return;
            }

            // -> PUSH/PULL IDLE
            IPushable pushable = _owner.Sensor.GetPushable();
            if(pushable != null
                && _owner.ActionReader.InteractAction)
            {
                StateMachine.ChangeState(CharacterState.PUSH_PULL_IDLE.ToString());
                return;
            }

            // -> WALK
            if (_owner.ActionReader.MoveAction.x != 0)
            {
                StateMachine.ChangeState(CharacterState.WALK.ToString());
                return;
            }

            // -> JUMP
            if (_owner.ActionReader.JumpAction)
            {
                StateMachine.ChangeState(CharacterState.JUMP.ToString());
                return;
            }
        }
        
        public void Exit()
        {
            
        }

    } // End of Class
}