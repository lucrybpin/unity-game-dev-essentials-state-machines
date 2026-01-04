using UnityEngine;

namespace StateMachines.Obstacles
{
    public class Ladder : MonoBehaviour, IClimbable
    {
        [SerializeField] Transform _bottomPoint;
        [SerializeField] Transform _topPoint;


        public Vector3 GetBotomPoint()
        {
            return _bottomPoint.position;
        }

        public Vector3 GetTopPoint()
        {
            return _topPoint.position;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_bottomPoint.position, 0.2f);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_topPoint.position, 0.2f);
        }
    }
}
