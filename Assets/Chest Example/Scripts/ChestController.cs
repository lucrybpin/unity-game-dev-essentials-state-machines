using UnityEngine;

namespace StateMachines.ChestExample
{
    [RequireComponent(typeof(ChestView))]
    public class ChestController : MonoBehaviour
    {
        [field: SerializeField] public StateMachine StateMachine { get; private set; }
        [SerializeField] ChestView _view;
        [SerializeField] bool _isClosed;

        void Awake()
        {
            StateMachine = new StateMachine();
            StateMachine.AddState(ChestState.CLOSED.ToString(), new ChestStateClosed(this));
            StateMachine.AddState(ChestState.OPEN.ToString(), new ChestStateOpen(this));
            _view = GetComponent<ChestView>();
            _isClosed = true;
        }

        void Start()
        {
            StateMachine.ChangeState(ChestState.CLOSED.ToString());
        }

        void Update()
        {
            StateMachine.Update();
        }

        public void Open()
        {
            _view.Open();
            _isClosed = false;
        }

        public void Close()
        {
            _view.Close();
            _isClosed = true;
        }

        // void OnClick()
        // {
        //     if (_isClosed)
        //     {
        //         _isClosed = false;
        //         _view.Open();
        //     }
        //     else
        //     {
        //         _isClosed = true;
        //         _view.Close();
        //     }
        // }

    } // End of Class
}