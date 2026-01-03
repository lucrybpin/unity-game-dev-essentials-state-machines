using UnityEngine;

namespace StateMachines.Obstacles
{
    public interface IPullable
    {
        public Transform GetTransform();
        public void SetPull(bool on, Rigidbody2D connectedBody);
    }
}
