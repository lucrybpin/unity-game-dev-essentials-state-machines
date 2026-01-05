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
        }
        
        public void Execute()
        {
            
        }
        
        public void Exit()
        {
            
        }
    }
}