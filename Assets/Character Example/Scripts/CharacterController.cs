using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CharacterController : MonoBehaviour
    {
        [field: SerializeField] public CharacterActionReader ActionReader { get; private set; }

        void OnEnable()
        {
            ActionReader.OnEnable();
        }

        void Update()
        {
            ActionReader.OnUpdate();
        }

        void OnDisable()
        {
            ActionReader.OnDisable();
        }

    } // End of Class
}
