using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class GameController : MonoBehaviour
    {
        //add setting for shooting delay
        [SerializeField] private float shootingDelay = 0.5f;
        //add delay timer for shooting
        private float shootingDelayTimer = 0f;

        //private inputDirection Vector2
        private Vector2 inputDirection;

        //getter for inputDirection
        public Vector2 InputDirection => inputDirection;

        //private variable isShooting and getter
        private bool isFire;
        public bool IsFire => isFire;


        private void Update()
        {
            inputDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
            UpdateShooting();
        }

        public void UpdateShooting()
        {
            isFire = false;
            var input_shooting = Input.GetKey("space");

            if (input_shooting && shootingDelayTimer <= 0f)
            {
                isFire = true;
                shootingDelayTimer = shootingDelay;
            }

            if (shootingDelayTimer > 0f)
            {
                shootingDelayTimer -= Time.deltaTime;
            }
        }
    }
}