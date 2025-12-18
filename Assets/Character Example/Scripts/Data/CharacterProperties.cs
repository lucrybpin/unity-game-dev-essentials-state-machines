using UnityEngine;

namespace StateMachines.CharacterExample
{
    [CreateAssetMenu(fileName = "Character Properties", menuName = "Scriptable Objects/CharacterProperties")]
    public class CharacterProperties : ScriptableObject
    {
        [Header("Movement Data")]
        public float WalkSpeed;
        public float JumpSpeed;
    }
}
