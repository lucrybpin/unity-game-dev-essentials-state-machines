using UnityEngine;

namespace StateMachines.Obstacles
{
    public interface IPushable
    {
        public Transform GetTransform();
        public void SetPush(bool on);
    }
}
