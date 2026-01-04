using System;
using UnityEngine;

namespace StateMachines.Obstacles
{
    public class ClimbSensor : MonoBehaviour
    {
        [SerializeField] bool _haveClimble;
        IClimbable _climbable;

        public event Action<IClimbable> OnClimbableSensorChanged;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IClimbable>(out IClimbable climable))
            {
                _climbable = climable;
                _haveClimble = true;
                OnClimbableSensorChanged?.Invoke(_climbable);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<IClimbable>(out IClimbable climable))
            {
                _climbable = null;
                _haveClimble = false;
                OnClimbableSensorChanged?.Invoke(null);
            }
        }
    }
}
