using UnityEngine;

namespace StateMachines.CharacterExample
{
    [CreateAssetMenu(fileName = "Character Properties", menuName = "Scriptable Objects/CharacterProperties")]
    public class CharacterProperties : ScriptableObject
    {
        public LayerMask ObstacleLayer;

        [Header("Movement Data")]
        public float GroundCheckRayLength;
        public float WalkSpeed;
        public float CrouchSpeed;
        public float JumpSpeed;
    }
}
