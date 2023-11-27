using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class SpaceShipDisplay : MonoBehaviour
    {
        //Reference to gameobject of idle animation 
        [SerializeField] private GameObject idleAnimation;
        //Reference to gameobject of death animation
        [SerializeField] private GameObject deathAnimation;

        private void Start()
        {
            PlayIdleAnimation();
        }

        public void PlayIdleAnimation()
        {
            //set idle animation to active
            idleAnimation.SetActive(true);
            //set death animation to inactive
            deathAnimation.SetActive(false);
        }

        public void PlayDeathAnimation()
        {
            //set idle animation to inactive
            idleAnimation.SetActive(false);
            //set death animation to active
            deathAnimation.SetActive(true);
        }
    }
}