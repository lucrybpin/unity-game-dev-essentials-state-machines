using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class RollState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        float _direction;
        
        public RollState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.Play("Crouch.Roll");
            _direction = _owner.ActionReader.MoveAction.x;
        }
        
        public void Execute()
        {
            // -> FALL
            if (!_owner.Movement.IsGrounded)
            {
                StateMachine.ChangeState(CharacterState.FALL.ToString());
                return;
            }

            // -> CROUCH (end of animation)
            AnimatorStateInfo stateInfo = _owner.Animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Roll") && stateInfo.normalizedTime >= 0.95)
            {
                StateMachine.ChangeState(CharacterState.CROUCH.ToString());
                return;
            }

            _owner.Movement.SetVelocity(x: _direction * _owner.Movement.RollSpeed);
        }
        
        public void Exit()
        {
            
        }
    }
}