namespace StateMachines.CharacterExample
{
    public class JumpState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        
        public JumpState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.Play("Jump");
            _owner.Movement.SetVelocity(y: _owner.Movement.JumpSpeed);
        }

        public void Execute()
        {
            // -> FALL
            if (_owner.Movement.Velocity.y <= 0)
            {
                StateMachine.ChangeState(CharacterState.FALL.ToString());
                return;
            }
        }

        public void Exit() { }

    } // End of Class
}