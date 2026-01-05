using System;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class ClimbState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        
        public ClimbState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.Play("Climb");
            _owner.Movement.SimulatedRigidbody(false);

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
            }
        }

        void AnimateDown()
        {
            if (_owner.ActionReader.MoveAction.y < 0)
            {
                _owner.transform.position -= 0.5f * Vector3.up;
            }
        }
    }
}