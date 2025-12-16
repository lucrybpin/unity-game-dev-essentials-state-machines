using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CharacterController : MonoBehaviour
    {
        [field: SerializeField] public CharacterActionReader ActionReader { get; private set; }
        [field: SerializeField] public CharacterMovement Movement { get; private set; }

        void Awake()
        {
            Movement = new CharacterMovement(GetComponent<Rigidbody2D>());
        }

        void OnEnable()
        {
            ActionReader.OnEnable();
        }

        void Update()
        {
            ActionReader.OnUpdate();
            // Movement.SetVelocity(ActionReader.MoveAction.x, Movement.RigidBody.linearVelocityY);
            Movement.SetVelocity(x: ActionReader.MoveAction.x);
        }

        void OnDisable()
        {
            ActionReader.OnDisable();
        }

    } // End of Class
}
