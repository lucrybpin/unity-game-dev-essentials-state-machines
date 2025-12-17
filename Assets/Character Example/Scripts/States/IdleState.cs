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
            
        }
        
        public void Exit()
        {
            
        }
    }
}