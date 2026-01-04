using System;
using UnityEngine;

namespace StateMachines.Obstacles
{
    public class PullSensor : MonoBehaviour
    {
        [SerializeField] bool _havePullable;
        IPullable _pullable;

        public event Action<IPullable> OnPullSensorChanged;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IPullable>(out IPullable pullable))
            {
                _pullable = pullable;
                _havePullable = true;
                OnPullSensorChanged?.Invoke(_pullable);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<IPullable>(out IPullable pullable))
            {
                _pullable = null;
                _havePullable = false;
                OnPullSensorChanged?.Invoke(null);
            }
        }
    }
}