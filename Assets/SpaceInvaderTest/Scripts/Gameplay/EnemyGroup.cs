using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class EnemyGroup : MonoBehaviour
    {
        //serealized enemy group planner
        [SerializeField] private EnemyGroupFactory enemyGroupPlanner;

        //serialized PlayArea:RectTransform
        [SerializeField] private BoxCollider2D colliderPlayArea;

        //EnemyMovementSettings
        [SerializeField] private EnemyMovementSettings enemyMovementSettings;

        List<Enemy> enemies = new List<Enemy>();
        private Bounds bounds;
        private Vector3 boundsOffset;
        private float enemyGroupSpeedRatio;
        private int defaultEnemyCount;
        private int remainingEnemyCount;
        private bool enemyGroupCompleted;

        // Start is called before the first frame update
        void Start()
        {
        }

        public void Setup()
        {
            enemyGroupCompleted = false;
            enemies = enemyGroupPlanner.PopulateEnemies();

            defaultEnemyCount = enemies.Count;

            //set enemies callbacks to recalculateworldbounds
            foreach (var enemy in enemies)
            {
                enemy.OnDestroyed += RecalculateWorldBoundsOnEnemyDead;
            }

            RecalculateWorldBounds();
            RecalculateEnemyCount();
            StartCoroutine(CoMoveEnemies());
        }

        void RecalculateWorldBoundsOnEnemyDead(Enemy enemy)
        {
            RecalculateWorldBounds();
            RecalculateEnemyCount();
        }

        void RecalculateWorldBounds()
        {
            this.bounds = GetWorldBounds();
            this.boundsOffset = transform.position - bounds.center;
        }

        void RecalculateEnemyCount()
        {
            remainingEnemyCount = enemies.Count(e => e != null && e.IsAlive);
            enemyGroupSpeedRatio = 1 - (float) remainingEnemyCount / defaultEnemyCount;
        }

        //calculate combined world bound of all enemies
        Bounds GetWorldBounds()
        {
            //force update 2d physics
            Physics2D.SyncTransforms();

            //create new bounds
            Bounds result = new Bounds();
            bool first_enemy = true;

            //loop through enemies
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == null || enemies[i].IsAlive == false)
                    continue;

                //if this is the first enemy
                if (first_enemy)
                {
                    //set bounds to this enemy world bound
                    result = enemies[i].GetWorldBounds();
                    first_enemy = false;
                }
                else
                {
                    //encapsulate bounds with this enemy world bound
                    result.Encapsulate(enemies[i].GetWorldBounds());
                }
            }

            //return bounds
            return result;
        }

        bool EnemiesOverflowBoundsLeft()
        {
            bounds.center = transform.position - boundsOffset;
            return (bounds.min.x) < colliderPlayArea.bounds.min.x;
        }

        bool EnemiesOverflowBoundsRight()
        {
            bounds.center = transform.position - boundsOffset;
            return (bounds.max.x) > colliderPlayArea.bounds.max.x;
        }

        bool EnemiesOverflowBoundsBottom()
        {
            bounds.center = transform.position - boundsOffset;
            return bounds.min.y < colliderPlayArea.bounds.min.y;
        }

        //Generate coroutine move enemies
        IEnumerator CoMoveEnemies()
        {
            yield return null;

            Vector3 direction = Vector3.left;

            //loop forever
            while (true)
            {
                bool overflow_horizontally = (direction.x < 0 && EnemiesOverflowBoundsLeft()) || (direction.x > 0 && EnemiesOverflowBoundsRight());

                if (overflow_horizontally)
                {
                    var old_position = transform.position;
                    var new_position = transform.position + Vector3.down * enemyMovementSettings.VerticalStepDistance;
                    var dropdown_duration = this.enemyMovementSettings.GetDropdownDuration(enemyGroupSpeedRatio);

                    for (var i = 0f; i < dropdown_duration; i += Time.deltaTime)
                    {
                        transform.position = Vector3.Lerp(old_position, new_position, i / dropdown_duration);
                        //wait for a frame
                        yield return null;
                    }
                    transform.transform.position = new_position;

                    //reverse the move direction
                    direction = -direction;


                    if (EnemiesOverflowBoundsBottom() || remainingEnemyCount <= 0)
                    {
                        enemyGroupCompleted = true;
                        yield break;
                    }
                }

                var speed = this.enemyMovementSettings.GetSpeed(enemyGroupSpeedRatio);
                transform.Translate(direction * speed * Time.deltaTime);

                //wait for a frame
                yield return null;
            }
        }

        public bool EnemyGroupCompleted => enemyGroupCompleted;
        public bool EnemyGroupCompletedCleared => enemyGroupCompleted && remainingEnemyCount <= 0;
        public bool EnemyGroupCompletedRemaining => enemyGroupCompleted && remainingEnemyCount > 0;
    }
}