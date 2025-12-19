using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CrouchSensor : MonoBehaviour
    {
        [SerializeField] List<GameObject> _colliders;

        public event Action<List<GameObject>> OnCrouchSensorChanged;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
                _colliders.Add(other.gameObject);

            OnCrouchSensorChanged?.Invoke(_colliders);
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
                _colliders.Remove(other.gameObject);

            OnCrouchSensorChanged?.Invoke(_colliders);
        }
    }
}
