using UnityEngine;

namespace StateMachines.BearExample
{
    public class BearWalkForward : IState
    {
        public StateMachine StateMachine { get; set; }
        Bear _owner;
        
        public BearWalkForward(Bear owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.CrossFade("Walk Forward", 0.1f);
        }
        
        public void Execute()
        {
            if (_owner.Input.y == 0)
            {
                StateMachine.ChangeState("Idle");
                return;
            }

            if (_owner.Input.y < 0)
            {
                StateMachine.ChangeState("Walk Back");
                return;
            }
        }
        
        public void Exit()
        {
            
        }
    }
}