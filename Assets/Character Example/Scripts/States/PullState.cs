using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class PullState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        float _enteringDirection;
        
        public PullState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _enteringDirection = _owner.Movement.FacingDirection;
            _owner.Animator.Play("Push Pull.Pull");
        }
        
        public void Execute()
        {
            
        }
        
        public void Exit()
        {
            
        }
    }
}