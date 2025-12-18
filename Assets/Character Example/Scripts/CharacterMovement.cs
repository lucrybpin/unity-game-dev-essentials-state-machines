using System;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    [Serializable]
    public class CharacterMovement
    {
        [field: SerializeField] public bool IsGrounded { get; private set; }
        [field: SerializeField] public Rigidbody2D RigidBody { get; private set; }
        [field: SerializeField] public float WalkSpeed { get; private set; }
        [field: SerializeField] public float CrouchSpeed { get; private set; }
        [field: SerializeField] public float JumpSpeed { get; private set; }
        [field: SerializeField] public Vector2 Velocity { get; private set; }

        [SerializeField] LayerMask _obstacleLayer;
        [SerializeField] float _groundCheckRayLength;

        public CharacterMovement(CharacterProperties properties, Rigidbody2D rigidbody)
        {
            _obstacleLayer          = properties.ObstacleLayer;
            _groundCheckRayLength   = properties.GroundCheckRayLength;
            WalkSpeed               = properties.WalkSpeed;
            CrouchSpeed             = properties.CrouchSpeed;
            JumpSpeed               = properties.JumpSpeed;
            RigidBody               = rigidbody;
        }

        public void OnUpdate()
        {
            IsGrounded  = Physics2D.Raycast(RigidBody.transform.position, Vector2.down, _groundCheckRayLength, _obstacleLayer);
            Velocity    = RigidBody.linearVelocity;
        }

        public void SetVelocity(float x, float y)
        {
            if(x > 0) RigidBody.transform.localScale = new Vector3(1,1,1);
            else if(x < 0) RigidBody.transform.localScale = new Vector3(-1,1,1);

            RigidBody.linearVelocity = new Vector2(x,y);
        }

        public void SetVelocity(float ? x = null, float ? y = null)
        {
            Vector3 currentVelocity = RigidBody.linearVelocity;

            float newX = x ?? currentVelocity.x;
            float newY = y ?? currentVelocity.y;

            SetVelocity(newX, newY);
        }

        public void DebugRays()
        {
            if(!Application.isPlaying)
                return;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(RigidBody.transform.position, RigidBody.transform.position + new Vector3(0f, -_groundCheckRayLength, 0f));
        }
        
    } // End of Class
}
