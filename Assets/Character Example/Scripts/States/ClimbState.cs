using StateMachines.Obstacles;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class ClimbState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        Vector3 _bottomPoint;
        Vector3 _topPoint;
        Vector3 _topOffset;

        public ClimbState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            IClimbable climbable = _owner.Sensor.SensorData.Climbable;

            _bottomPoint = climbable.GetBotomPoint();
            _topPoint = climbable.GetTopPoint();

            float distanceToBottom = Vector3.Distance(_owner.transform.position, _bottomPoint);
            float distanceToTop = Vector3.Distance(_owner.transform.position, _topPoint);

            bool isAtBottom = distanceToBottom < distanceToTop;

            if (isAtBottom)
            {
                if (_owner.ActionReader.MoveAction.y < 0)
                {
                    StateMachine.ChangeState(CharacterState.IDLE.ToString());
                    return;
                }
            }
            else
            {
                if (_owner.ActionReader.MoveAction.y > 0)
                {
                    StateMachine.ChangeState(CharacterState.IDLE.ToString());
                    return;
                }
            }

            _owner.Animator.Play("Climb");
            _owner.Movement.SimulatedRigidbody(false);

            _topOffset = 1.3f * Vector3.down;
            _owner.transform.position = (isAtBottom) ? _bottomPoint : _topPoint + _topOffset;

            _owner.AnimationEvents.OnEvent1 += AnimateUp;
            _owner.AnimationEvents.OnEvent2 += AnimateDown;
            _owner.AnimationEvents.OnEvent3 += AnimateUp;
            _owner.AnimationEvents.OnEvent4 += AnimateDown;
        }

        public void Execute()
        {
            if (_owner.ActionReader.MoveAction.y == 0)
            {
                _owner.Animator.speed = 0;
            }
            else
            {
                _owner.Animator.speed = 1;
            }
        }
        
        public void Exit()
        {
            _owner.AnimationEvents.OnEvent1 -= AnimateUp;
            _owner.AnimationEvents.OnEvent2 -= AnimateDown;
            _owner.AnimationEvents.OnEvent3 -= AnimateUp;
            _owner.AnimationEvents.OnEvent4 -= AnimateDown;
        }

        void AnimateUp()
        {
            if (_owner.ActionReader.MoveAction.y > 0)
            {
                _owner.transform.position += 0.5f * Vector3.up;
                float distance = Vector3.Distance(_owner.transform.position, _topPoint + _topOffset);
                if (distance <= 0.5f)
                {
                    _owner.transform.position = _topPoint;
                    _owner.Movement.SimulatedRigidbody(true);
                    StateMachine.ChangeState(CharacterState.IDLE.ToString());
                    return;
                }
            }
        }

        void AnimateDown()
        {
            if (_owner.ActionReader.MoveAction.y < 0)
            {
                _owner.transform.position -= 0.5f * Vector3.up;
                float distance = Vector3.Distance(_owner.transform.position, _bottomPoint);
                if (distance <= 0.5f)
                {
                    _owner.transform.position = _bottomPoint;
                    _owner.Movement.SimulatedRigidbody(true);
                    StateMachine.ChangeState(CharacterState.IDLE.ToString());
                    return;
                }
            }
        }
    }
}