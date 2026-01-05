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
            _owner.AnimationEvents.OnEvent3 += AnimateUp;
        }

        public void Execute()
        {
            
        }
        
        public void Exit()
        {
            _owner.AnimationEvents.OnEvent1 -= AnimateUp;
            _owner.AnimationEvents.OnEvent3 -= AnimateUp;
        }

        void AnimateUp()
        {
            if (_owner.ActionReader.MoveAction.y > 0)
            {
                _owner.transform.position += 0.5f * Vector3.up;
            }
        }
    }
}