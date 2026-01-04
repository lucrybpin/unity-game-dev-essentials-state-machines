using UnityEngine;

namespace StateMachines.Obstacles
{
    public interface IClimbable
    {
        public Vector3 GetBotomPoint();
        public Vector3 GetTopPoint();
    }
}
