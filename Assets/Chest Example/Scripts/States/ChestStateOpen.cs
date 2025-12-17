using UnityEngine;

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

        public void Enter()
        {
        }

        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _chestController.Close();
                StateMachine.ChangeState(ChestState.CLOSED.ToString());
                return;
            }
        }

        public void Exit()
        {
        }
    }
}
