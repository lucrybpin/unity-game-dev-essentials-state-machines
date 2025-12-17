namespace StateMachines.ChestExample
{
    public class ChestStateClosed : IState
    {
        public StateMachine StateMachine { get; set; }

        ChestController _chestController;

        public ChestStateClosed(ChestController chestController)
        {
            _chestController = chestController;
        }

        void OnClick()
        {
            _chestController.Open();
            StateMachine.ChangeState(ChestState.OPEN.ToString());
        }

        public void Enter()
        {
            _chestController.View.OnClick += OnClick;
        }

        public void Execute() { }

        public void Exit()
        {
            _chestController.View.OnClick -= OnClick;
        }

    } // End of Class
}
