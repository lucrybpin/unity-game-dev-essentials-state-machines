using UnityEngine;

namespace StateMachines.Obstacles
{
    public class PullablePoint : MonoBehaviour, IPullable
    {
        [SerializeField] Rigidbody2D _rigidBody2d;
        [SerializeField] FixedJoint2D _joint;

        public Transform GetTransform()
        {
            return _rigidBody2d.transform;
        }

        public void SetPull(bool on, Rigidbody2D connectedBody)
        {
            if (on)
            {
                _rigidBody2d.mass = 2;
                _joint.enabled = true;
                _joint.connectedBody = connectedBody;
            }
            else
            {
                _rigidBody2d.mass = 50;
                _joint.enabled = false;
                _joint.connectedBody = null;
            }
        }
    }
}