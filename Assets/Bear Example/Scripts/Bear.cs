using System;
using UnityEditorInternal;
using UnityEngine;

namespace StateMachines.BearExample
{
    public class Bear : MonoBehaviour
    {
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Vector2 Input { get; private set; }
        [field: SerializeField] public StateMachine StateMachine { get; private set; }

        public event Action<float> OnMove;

        void Awake()
        {
            StateMachine = new StateMachine();
        }

        void Start()
        {
            StateMachine.AddState("Idle", new BearIdle(this));
            StateMachine.AddState("Walk Forward", new BearWalkForward(this));
            StateMachine.AddState("Walk Back", new BearWalkBack(this));
            StateMachine.AddState("Eat", new BearEat(this));

            StateMachine.ChangeState("Idle");
        }

        void Update()
        {
            Input = new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));

            StateMachine.Update();

            OnMove?.Invoke(Input.y);
        }

    } // End of Class
}