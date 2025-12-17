namespace StateMachines.ChestExample
{
    public class ChestStateOpen : IState
    {
        public StateMachine StateMachine { get; set; }
        ChestController _chestController;

        public ChestStateOpen(ChestController chestController)
        {
            _chestController = chestController;
        }

        void OnClick()
        {
            _chestController.Close();
            StateMachine.ChangeState(ChestState.CLOSED.ToString());
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
