using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CharacterController : MonoBehaviour
    {
        [field: SerializeField] public CharacterActionReader ActionReader { get; private set; }
        [field: SerializeField] public CharacterMovement Movement { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }

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

            if (ActionReader.MoveAction.x != 0)
            {
                Animator.Play("Walk");
            }
            else
            {
                Animator.Play("Idle");
            }

            Movement.SetVelocity(x: ActionReader.MoveAction.x);
        }

        void OnDisable()
        {
            ActionReader.OnDisable();
        }

    } // End of Class
}
