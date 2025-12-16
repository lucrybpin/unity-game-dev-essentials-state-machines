using UnityEngine;

namespace StateMachines.ChestExample
{
    [RequireComponent(typeof(ChestView))]
    public class ChestController : MonoBehaviour
    {
        [SerializeField] ChestView _view;
        [SerializeField] bool _isClosed;

        void Awake()
        {
            _view = GetComponent<ChestView>();
            _isClosed = true;
        }

        void Start()
        {
            _view.OnClick += OnClick;
        }

        void OnClick()
        {
            if (_isClosed)
            {
                _isClosed = false;
                _view.Open();
            }
            else
            {
                _isClosed = true;
                _view.Close();
            }
        }

    } // End of Class
}