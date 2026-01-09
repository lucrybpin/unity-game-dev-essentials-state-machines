using UnityEngine;

namespace StateMachines.BearExample
{
    public class BearIdle : IState
    {
        public StateMachine StateMachine { get; set; }
        Bear _owner;
        
        public BearIdle(Bear owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.CrossFade("Idle", 0.1f);
        }
        
        public void Execute()
        {
            if (_owner.Input.y > 0)
            {
                StateMachine.ChangeState("Walk Forward");
                return;
            }

            if (_owner.Input.y < 0)
            {
                StateMachine.ChangeState("Walk Back");
                return;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                StateMachine.ChangeState("Eat");
                return;
            }
        }
        
        public void Exit()
        {
            
        }
    }
}