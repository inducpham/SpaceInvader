using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    [System.Serializable]
    public class EnemyMovementSettings
    {
        //verticalStepDistance:float and getter
        [SerializeField] private float _verticalStepDistance = 1f;
        public float VerticalStepDistance { get { return _verticalStepDistance; } }


        [SerializeField] private float _speed = 4f;
        public float Speed { get { return _speed; } }

        [SerializeField] private float _maxSpeed = 4f;
        public float MaxSpeed { get { return _maxSpeed; } }

        [SerializeField] private float _dropdownDuration = 4f;
        public float DropdownDuration { get { return _dropdownDuration; } }

        [SerializeField] private float _maxDropdownDuration = 4f;
        public float MaxDropdownDuration { get { return _maxDropdownDuration; } }

        //GetSpeed based on ratio from 0 to 1
        public float GetSpeed(float ratio)
        {
            return Mathf.Lerp(_speed, _maxSpeed, ratio);
        }

        //GetDropdownDuration based on ratio from 0 to 1
        public float GetDropdownDuration(float ratio)
        {
            return Mathf.Lerp(_dropdownDuration, _maxDropdownDuration, ratio);
        }
    }
}