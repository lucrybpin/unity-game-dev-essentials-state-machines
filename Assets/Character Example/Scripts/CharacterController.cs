using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CharacterController : MonoBehaviour
    {
        [field: SerializeField] public CharacterProperties CharacterProperties { get; private set; }
        [field: SerializeField] public CharacterActionReader ActionReader { get; private set; }
        [field: SerializeField] public CharacterMovement Movement { get; private set; }
        [field: SerializeField] public CharacterSensor Sensor { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public StateMachine StateMachine { get; private set; }

        [SerializeField] GameObject _pushHands;
        [SerializeField] bool _debug;

        void Awake()
        {
            Movement        = new CharacterMovement(CharacterProperties, GetComponent<Rigidbody2D>(), _pushHands);
            Sensor          = new CharacterSensor(this);
            StateMachine    = new StateMachine();

            StateMachine.AddState(CharacterState.IDLE.ToString(), new IdleState(this));
            StateMachine.AddState(CharacterState.WALK.ToString(), new WalkState(this));
            StateMachine.AddState(CharacterState.JUMP.ToString(), new JumpState(this));
            StateMachine.AddState(CharacterState.FALL.ToString(), new FallState(this));
            StateMachine.AddState(CharacterState.CROUCH.ToString(), new CrouchState(this));
            StateMachine.AddState(CharacterState.ROLL.ToString(), new RollState(this));
            StateMachine.AddState(CharacterState.RUN.ToString(), new RunState(this));
            StateMachine.AddState(CharacterState.PUSH_PULL_IDLE.ToString(), new PushPullIdleState(this));
            StateMachine.AddState(CharacterState.PUSH.ToString(), new PushState(this));
            StateMachine.AddState(CharacterState.PULL.ToString(), new PullState(this));
            StateMachine.AddState(CharacterState.CLIMB.ToString(), new ClimbState(this));
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
            Movement.OnUpdate();
            StateMachine.Update();
            Sensor.OnUpdate();
        }

        void OnDisable()
        {
            ActionReader.OnDisable();
        }

        void OnDrawGizmos()
        {
            if(!_debug)
                return;

            Movement.DebugRays();
            Sensor.DebugRays();
        }

    } // End of Class
}
