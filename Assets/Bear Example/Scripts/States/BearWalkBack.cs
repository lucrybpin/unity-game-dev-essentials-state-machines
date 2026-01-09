using UnityEditorInternal;
using UnityEngine;

namespace StateMachines.BearExample
{
    public class BearWalkBack : IState
    {
        public StateMachine StateMachine { get; set; }
        Bear _owner;
        
        public BearWalkBack(Bear owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.CrossFade("Walk Back", 0.1f);
        }
        
        public void Execute()
        {
            if (_owner.Input.y == 0)
            {
                StateMachine.ChangeState("Idle");
                return; 
            }

            if (_owner.Input.y > 0)
            {
                StateMachine.ChangeState("Walk Forward");
                return;
            }
        }
        
        public void Exit()
        {
            
        }
    }
}