using UnityEngine;

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

        public void Enter()
        {
            Debug.Log($">>>> Entered Closed State");
        }

        public void Execute()
        {
            Debug.Log($">>>> Running Closed State");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _chestController.Open();
                StateMachine.ChangeState(ChestState.OPEN.ToString());
                return;
            }
        }

        public void Exit()
        {
            Debug.Log($">>>> Exited Closed State");
            
        }

    } // End of Class
}
