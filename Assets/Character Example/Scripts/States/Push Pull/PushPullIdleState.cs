using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class PushPullIdleState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        float _enteringDirection;
        
        public PushPullIdleState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _enteringDirection = _owner.Movement.FacingDirection;
            _owner.Animator.Play("Push Pull.Push Pull Idle");

            Vector2 warpPosition =
                _owner.Sensor.SensorData.PushPullHit.point
                    + _owner.Movement.FacingDirection * Vector2.left * 0.7f;

            _owner.transform.position = warpPosition;
        }
        
        public void Execute()
        {
            // -> IDLE (pushable out of range)
            if (_owner.Sensor.GetPushable() == null)
            {
                StateMachine.ChangeState(CharacterState.IDLE.ToString());
                return;
            }

            // -> PUSH
            if(_owner.ActionReader.MoveAction.x == _enteringDirection)
            {
                StateMachine.ChangeState(CharacterState.PUSH.ToString());
                return;
            }

            // -> IDLE (move to other direction)
            if (_owner.ActionReader.MoveAction.x == -_enteringDirection
                && _owner.Sensor.GetPullable() != null)
            {
                StateMachine.ChangeState(CharacterState.PULL.ToString());
                return;
            }
            else if (_owner.ActionReader.MoveAction.x == -_enteringDirection
                && _owner.Sensor.GetPullable() == null)
            {
                StateMachine.ChangeState(CharacterState.IDLE.ToString());
                return;
            }

            // -> IDLE (exit Interaction mode)
            else if (_owner.ActionReader.InteractAction)
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