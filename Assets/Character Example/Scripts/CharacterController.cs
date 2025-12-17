using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CharacterController : MonoBehaviour
    {
        [field: SerializeField] public CharacterActionReader ActionReader { get; private set; }
        [field: SerializeField] public CharacterMovement Movement { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }

        [field: SerializeField] public StateMachine StateMachine { get; private set; }

        void Awake()
        {
            Movement        = new CharacterMovement(GetComponent<Rigidbody2D>());
            StateMachine    = new StateMachine();

            StateMachine.AddState(CharacterState.IDLE.ToString(), new IdleState(this));
        }

        void Start()
        {
            StateMachine.ChangeState(CharacterState.IDLE.ToString());
        }

        void OnEnable()
        {
            ActionReader.OnEnable();
        }

        void Update()
        {
            ActionReader.OnUpdate();
            StateMachine.Update();

            // if (ActionReader.MoveAction.x != 0)
            // {
            //     Animator.Play("Walk");
            // }
            // else
            // {
            //     Animator.Play("Idle");
            // }

            // Movement.SetVelocity(x: ActionReader.MoveAction.x);
        }

        void OnDisable()
        {
            ActionReader.OnDisable();
        }

    } // End of Class
}
