using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceInvaderTest
{
    public class EnemyDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject idleAnimation;
        [SerializeField] private GameObject deathAnimation;

        [SerializeField] private float deathAnimationLength = 1f;
        public float DeathAnimationLength => deathAnimationLength;

        private void Start()
        {
            PlayIdleAnimation();
        }

        public void PlayIdleAnimation()
        {
            idleAnimation.SetActive(true);
            deathAnimation.SetActive(false);
        }

        public void PlayDeathAnimation()
        {
            idleAnimation.SetActive(false);
            deathAnimation.SetActive(true);
        }
    }
}