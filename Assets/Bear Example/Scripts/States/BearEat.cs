using UnityEngine;

namespace StateMachines.BearExample
{
    public class BearEat : IState
    {
        public StateMachine StateMachine { get; set; }
        Bear _owner;
        
        public BearEat(Bear owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.CrossFade("Eat", 0.1f);
        }
        
        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StateMachine.ChangeState("Idle");
                return;
            }
        }
        
        public void Exit()
        {
            
        }
    }
}