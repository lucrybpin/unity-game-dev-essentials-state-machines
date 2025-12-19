using System;
using System.Collections.Generic;
using StateMachines.CharacterExample;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    [Serializable]
    public class SensorData
    {
        public bool HaveHeadObstacle;
    }

    [Serializable]
    public class CharacterSensor
    {
        [field: SerializeField] public  CharacterController Owner { get; private set; }
        [field: SerializeField] public SensorData SensorData { get; private set; }

        [SerializeField] CrouchSensor _crouchSensor;

        public CharacterSensor(CharacterController owner)
        {
            Owner = owner;
            SensorData = new SensorData();
            _crouchSensor = owner.GetComponentInChildren<CrouchSensor>();

            _crouchSensor.OnCrouchSensorChanged += UpdateCrouchSensor;
        }

        void UpdateCrouchSensor(List<GameObject> headObstacles)
        {
            SensorData.HaveHeadObstacle = headObstacles.Count == 0 ? false : true;
        }
    }
}
