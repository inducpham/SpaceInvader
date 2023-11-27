using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceInvaderTest
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Enemy : MonoBehaviour
    {
        //callback when enemy is destroyed
        public System.Action<Enemy> OnDestroyed = delegate { };

        [SerializeField] private EnemyDisplay display;

        private int hp;

        private DataEnemy data;
        public DataEnemy Data => data;

        //isAlive and getter
        private bool isAlive;
        public bool IsAlive => isAlive;

        //setup this enemy with data enemy
        public void Setup(DataEnemy dataEnemy)
        {
            this.data = dataEnemy;

            //remove previous enemy display
            if (display != null)
            {
                Destroy(display.gameObject);
            }

            //instantiate new enemy display from dataenemy
            display = Instantiate(dataEnemy.EnemyDisplay, transform).GetComponent<EnemyDisplay>();
            display.PlayIdleAnimation();

            //set isAlive to true
            isAlive = true;
            hp = dataEnemy.Hp;
        }

        //get world bound from component BoxCollider2D
        public Bounds GetWorldBounds()
        {
            return GetComponent<BoxCollider2D>().bounds;
        }

        public void DamageEnemy(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                isAlive = false;
                display.PlayDeathAnimation();
                StartCoroutine(CoDestroy());
            }
        }

        //CoDestroy
        IEnumerator CoDestroy()
        {
            OnDestroyed(this);

            //wait for death animation to finish
            yield return new WaitForSeconds(display.DeathAnimationLength);
            gameObject.SetActive(false);
        }
        
    }
}