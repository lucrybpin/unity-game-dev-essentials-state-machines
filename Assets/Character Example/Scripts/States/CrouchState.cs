namespace StateMachines.CharacterExample
{
    public class CrouchState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        
        public CrouchState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.Play("Crouch.Crouch Idle");
        }
        
        public void Execute()
        {
            // -> FALL
            if (!_owner.Movement.IsGrounded)
            {
                StateMachine.ChangeState(CharacterState.FALL.ToString());
                return;
            }

            // -> IDLE
            if (_owner.ActionReader.MoveAction.y >= 0
                && _owner.ActionReader.MoveAction.x == 0)
            {
                StateMachine.ChangeState(CharacterState.IDLE.ToString());
                return;
            }
            
            // -> WALK
            if (_owner.ActionReader.MoveAction.y >= 0
                && _owner.ActionReader.MoveAction.x != 0)
            {
                StateMachine.ChangeState(CharacterState.WALK.ToString());
                return;
            }

            if (_owner.ActionReader.MoveAction.x != 0)
            {
                _owner.Animator.Play("Crouch.Crouch Walk");
                _owner.Movement.SetVelocity(
                    x: _owner.Movement.CrouchSpeed * _owner.ActionReader.MoveAction.x
                );
            }
            else
            {
                _owner.Animator.Play("Crouch.Crouch Idle");
            }

        }
        
        public void Exit()
        {
            
        }

    } // End of Class
}