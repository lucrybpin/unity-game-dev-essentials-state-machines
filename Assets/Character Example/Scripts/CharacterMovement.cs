using System;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    [Serializable]
    public class CharacterMovement
    {
        [field: SerializeField] public Rigidbody2D RigidBody { get; private set; }
        [field: SerializeField] public float WalkSpeed { get; private set; }

        public CharacterMovement(CharacterProperties properties, Rigidbody2D rigidbody)
        {
            WalkSpeed = properties.WalkSpeed;
            RigidBody = rigidbody;
        }

        public void SetVelocity(float x, float y)
        {
            if(x > 0) RigidBody.transform.localScale = new Vector3(1,1,1);
            else if(x < 0) RigidBody.transform.localScale = new Vector3(-1,1,1);

            RigidBody.linearVelocity = new Vector2(x,y);
        }

        public void SetVelocity(float ? x, float ? y = null)
        {
            Vector3 currentVelocity = RigidBody.linearVelocity;

            float newX = x ?? currentVelocity.x;
            float newY = y ?? currentVelocity.y;

            SetVelocity(newX, newY);
        }
        
    } // End of Class
}
