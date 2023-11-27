using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

namespace SpaceInvaderTest
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Bullet : MonoBehaviour
    {
        //serialized speed:float
        [SerializeField] private float speed = 10f;
        //serialized damage:int
        [SerializeField] private int damage = 1;

        //reference to groupParticle and groupExplosion
        [SerializeField] private GameObject groupParticle;
        [SerializeField] private GameObject groupExplosion;
        [SerializeField] private float explosionDuration = 0.5f;

        private Vector2 direction = Vector2.up;    
        private Rigidbody2D rigidbody2D;
        private GameObject owner;
        private BoxCollider2D activeArea;
        private bool isAlive = true;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Spawn(GameObject owner, Vector2 direction, BoxCollider2D activeArea)
        {
            gameObject.SetActive(true);

            this.transform.position = owner.transform.position;
            this.owner = owner;
            this.direction = direction.normalized;
            this.activeArea = activeArea;

            //show particle and hide explosion
            this.isAlive = true;
            this.groupParticle.SetActive(true);
            this.groupExplosion.SetActive(false);
        }
    
        private void OnEnable()
        {
            //set the velocity of the bullet to the direction and speed
            rigidbody2D.velocity = direction * speed;
        }
    
        private void OnDisable()
        {
            //reset the velocity of the bullet
            rigidbody2D.velocity = Vector2.zero;
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (gameObject.activeSelf == false || isAlive == false) return;
            if (collision == null) return;
            var enemy = collision.GetComponent<Enemy>();
            if (enemy == null || enemy.IsAlive == false) return;

            var collisionPosition = (transform.position + collision.transform.position) / 2f;
            groupExplosion.transform.position = collisionPosition;
            HitEnemy(enemy, collisionPosition);
        }

        protected virtual void HitEnemy(Enemy enemy, Vector3 collisionPosition)
        {
            enemy.DamageEnemy(damage);
            ClearBullet();
        }

        protected void ClearBullet()
        {
            rigidbody2D.velocity = Vector2.zero;
            groupParticle.SetActive(false);
            groupExplosion.SetActive(true);
            this.isAlive = false;

            //wait for explosion animation to finish
            StartCoroutine(CoDestroy());
        }

        IEnumerator CoDestroy()
        {
            //wait for explosion animation to finish
            yield return new WaitForSeconds(explosionDuration);
            gameObject.SetActive(false);
        }

        //on Update, check if the bullet is out of sceneBound, if it is, disable the bullet
        private void Update()
        {
            if (activeArea.bounds.Contains(transform.position)) return;
            gameObject.SetActive(false);
        }
    }
}