using UnityEngine;

namespace StateMachines.Obstacles
{
    public class PushableBox : MonoBehaviour, IPushable
    {
        [SerializeField] Rigidbody2D _rigidBody2D;

        void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void SetPush(bool on)
        {
            _rigidBody2D.mass = on ? 2 : 50;
        }
    }
}