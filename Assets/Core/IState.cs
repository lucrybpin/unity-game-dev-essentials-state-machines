namespace StateMachines
{
    public interface IState
    {
        public StateMachine StateMachine { get; set; }
        void Enter();
        void Execute();
        void Exit();
    }
}
