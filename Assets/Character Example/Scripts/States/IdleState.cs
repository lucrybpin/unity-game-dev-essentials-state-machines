namespace StateMachines.CharacterExample
{
    public class IdleState : IState
    {
        public StateMachine StateMachine { get; set; }
        CharacterController _owner;
        
        public IdleState(CharacterController owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _owner.Animator.Play("Idle");
            _owner.Movement.SetVelocity(x: 0);
        }
        
        public void Execute()
        {
            // -> WALK
            if (_owner.ActionReader.MoveAction.x != 0)
            {
                StateMachine.ChangeState(CharacterState.WALK.ToString());
                return;
            }

            // -> JUMP
            if (_owner.ActionReader.JumpAction)
            {
                StateMachine.ChangeState(CharacterState.JUMP.ToString());
                return;
            }
        }
        
        public void Exit()
        {
            
        }

    } // End of Class
}