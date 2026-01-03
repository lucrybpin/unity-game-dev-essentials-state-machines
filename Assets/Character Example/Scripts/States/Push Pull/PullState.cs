using StateMachines.Obstacles;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class PullState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        float _enteringDirection;
        IPullable _pullableObject;
        
        public PullState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _enteringDirection = _owner.Movement.FacingDirection;
            _owner.Animator.Play("Push Pull.Pull");
            _pullableObject = _owner.Sensor.GetPullable();
            _pullableObject.SetPull(true, _owner.Movement.RigidBody);
        }
        
        public void Execute()
        {
            // -> PUSH/PULL IDLE
            if (_owner.ActionReader.MoveAction.x == 0)
            {
                StateMachine.ChangeState(CharacterState.PUSH_PULL_IDLE.ToString());
                return;
            }

            if(_owner.ActionReader.MoveAction.x == -_enteringDirection)
            {
                _owner.Movement.SetVelocity(
                    x: _owner.Movement.PushSpeed * _owner.ActionReader.MoveAction.x,
                    ignoreFlip: true
                );
            }
        }
        
        public void Exit()
        {
            _pullableObject.SetPull(false, _owner.Movement.RigidBody);
        }
    }
}