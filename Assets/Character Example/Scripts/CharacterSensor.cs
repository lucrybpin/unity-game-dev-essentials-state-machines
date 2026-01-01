using System;
using System.Collections.Generic;
using StateMachines.CharacterExample;
using StateMachines.Obstacles;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachines.CharacterExample
{
    [Serializable]
    public class SensorData
    {
        public bool HavePushPull;
        public RaycastHit2D PushPullHit;
        public bool HaveHeadObstacle;
    }

    [Serializable]
    public class CharacterSensor
    {
        [field: SerializeField] public  CharacterController Owner { get; private set; }
        [field: SerializeField] public SensorData SensorData { get; private set; }
        [SerializeField] float _pushPullRayLenght;
        [SerializeField] LayerMask _obstacleLayer;

        [SerializeField] CrouchSensor _crouchSensor;

        public void OnUpdate()
        {
            SensorData.PushPullHit = Physics2D.Raycast(Owner.transform.position, Owner.Movement.FacingDirection * Vector2.right, _pushPullRayLenght, _obstacleLayer);
            if(SensorData.PushPullHit.collider != null)
            {
                SensorData.HavePushPull = true;
            }
            else
            {
                SensorData.HavePushPull = false;
            }
        }

        public CharacterSensor(CharacterController owner)
        {
            Owner = owner;
            SensorData = new SensorData();
            _crouchSensor = owner.GetComponentInChildren<CrouchSensor>();
            _pushPullRayLenght = owner.CharacterProperties.PushPullRayLength;
            _obstacleLayer = owner.CharacterProperties.ObstacleLayer;

            _crouchSensor.OnCrouchSensorChanged += UpdateCrouchSensor;
        }

        void UpdateCrouchSensor(List<GameObject> headObstacles)
        {
            SensorData.HaveHeadObstacle = headObstacles.Count == 0 ? false : true;
        }

        public IPushable GetPushable()
        {
            IPushable pushableFound = null;
            if(SensorData.PushPullHit)
                SensorData.PushPullHit.collider.TryGetComponent(out pushableFound);

            return pushableFound;
        }

        public void DebugRays()
        {
            if(!Application.isPlaying)
                return;

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(Owner.transform.position, Owner.transform.position + new Vector3(Owner.Movement.FacingDirection * _pushPullRayLenght, 0f, 0f));
        }
    }
}
