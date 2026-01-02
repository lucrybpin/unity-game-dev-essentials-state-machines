using StateMachines.Obstacles;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class PushState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        float _enteringDirection;
        IPushable _pushableObstacle;
        
        public PushState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _enteringDirection = _owner.Movement.FacingDirection;
            _pushableObstacle = _owner.Sensor.GetPushable();

            if (_pushableObstacle == null)
            {
                StateMachine.ChangeState(CharacterState.IDLE.ToString());
                _owner.Movement.SetHandsCollision(false);
                return;
            }

            _owner.Movement.SetHandsCollision(true);
            _owner.Animator.Play("Push Pull.Push");
            _pushableObstacle.SetPush(true);
        }
        
        public void Execute()
        {
            // -> IDLE
            if (_owner.Sensor.GetPushable() == null)
            {
                StateMachine.ChangeState(CharacterState.IDLE.ToString());
                return;
            }

            if (_owner.ActionReader.MoveAction.x == _enteringDirection)
            {
                _owner.Movement.SetVelocity(x: _owner.CharacterProperties.PushSpeed * _owner.ActionReader.MoveAction.x);
                return;
            }

            // -> IDLE
            else if(_owner.ActionReader.MoveAction.x == -_enteringDirection)
            {
                StateMachine.ChangeState(CharacterState.IDLE.ToString());
                return;
            }

            // -> IDLE
            if (_owner.ActionReader.MoveAction.x == 0)
            {
                StateMachine.ChangeState(CharacterState.PUSH_PULL_IDLE.ToString());
                return;
            }
        }
        
        public void Exit()
        {
            _pushableObstacle?.SetPush(false);
            _owner.Movement.SetHandsCollision(false);
        }
    }
}