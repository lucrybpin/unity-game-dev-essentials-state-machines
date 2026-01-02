using System;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    [Serializable]
    public class CharacterMovement
    {
        [field: SerializeField] public bool IsGrounded { get; private set; }
        [field: SerializeField] public Rigidbody2D RigidBody { get; private set; }
        [field: SerializeField] public float FacingDirection { get; private set; }
        [field: SerializeField] public float WalkSpeed { get; private set; }
        [field: SerializeField] public float CrouchSpeed { get; private set; }
        [field: SerializeField] public float PushSpeed { get; private set; }
        [field: SerializeField] public float RunSpeed { get; private set; }
        [field: SerializeField] public float RollSpeed { get; private set; }
        [field: SerializeField] public float JumpSpeed { get; private set; }
        [field: SerializeField] public Vector2 Velocity { get; private set; }

        [SerializeField] LayerMask _obstacleLayer;
        [SerializeField] float _groundCheckRayLength;
        [SerializeField] CapsuleCollider2D _capsuleCollider;
        [SerializeField] GameObject _handCollider;

        public CharacterMovement(CharacterProperties properties, Rigidbody2D rigidbody, GameObject handCollider)
        {
            _obstacleLayer          = properties.ObstacleLayer;
            _groundCheckRayLength   = properties.GroundCheckRayLength;
            _capsuleCollider        = rigidbody.GetComponent<CapsuleCollider2D>();
            _handCollider           = handCollider;
            WalkSpeed               = properties.WalkSpeed;
            CrouchSpeed             = properties.CrouchSpeed;
            PushSpeed               = properties.PushSpeed;
            RunSpeed                = properties.RunSpeed;
            RollSpeed               = properties.RollSpeed;
            JumpSpeed               = properties.JumpSpeed;
            RigidBody               = rigidbody;
            FacingDirection         = 1;
        }

        public void OnUpdate()
        {
            IsGrounded  = Physics2D.Raycast(RigidBody.transform.position, Vector2.down, _groundCheckRayLength, _obstacleLayer);
            Velocity    = RigidBody.linearVelocity;
        }

        public void SetVelocity(float x, float y)
        {
            if(x > 0)
            {
                RigidBody.transform.localScale = new Vector3(1, 1, 1);
                FacingDirection = 1;
            } 
            else if(x < 0) {
                RigidBody.transform.localScale = new Vector3(-1,1,1);
                FacingDirection = -1;
            }

            RigidBody.linearVelocity = new Vector2(x,y);
        }

        public void SetVelocity(float ? x = null, float ? y = null)
        {
            Vector3 currentVelocity = RigidBody.linearVelocity;

            float newX = x ?? currentVelocity.x;
            float newY = y ?? currentVelocity.y;

            SetVelocity(newX, newY);
        }

        public void SetCrouch(bool isCrouching)
        {
            if (isCrouching)
            {
                _capsuleCollider.offset = new Vector2(0, -0.25f);
                _capsuleCollider.size = new Vector2(0.7f, 1.25f);
            }
            else
            {
                _capsuleCollider.offset = new Vector2(0, 0);
                _capsuleCollider.size = new Vector2(0.7f, 1.8f);
            }
        }

        public void SetHandsCollision(bool enabled)
        {
            _handCollider.SetActive(enabled);
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
