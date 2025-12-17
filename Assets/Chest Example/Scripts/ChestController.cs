using UnityEngine;

namespace StateMachines.ChestExample
{
    [RequireComponent(typeof(ChestView))]
    public class ChestController : MonoBehaviour
    {
        [field: SerializeField] public StateMachine StateMachine { get; private set; }
        [field: SerializeField] public ChestView View { get; private set; }

        void Awake()
        {
            StateMachine    = new StateMachine();
            View            = GetComponent<ChestView>();

            StateMachine.AddState(ChestState.CLOSED.ToString(), new ChestStateClosed(this));
            StateMachine.AddState(ChestState.OPEN.ToString(), new ChestStateOpen(this));
        }

        void Start()
        {
            StateMachine.ChangeState(ChestState.CLOSED.ToString());
        }

        public void Open()
        {
            View.Open();
        }

        public void Close()
        {
            View.Close();
        }

    } // End of Class
}