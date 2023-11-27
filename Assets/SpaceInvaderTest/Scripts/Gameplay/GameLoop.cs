using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class GameLoop : MonoBehaviour
    {

        //serialized private SpaceShip
        [SerializeField] private SpaceShip spaceShip;
        //serialized private EnemyGroup
        [SerializeField] private EnemyGroup enemyGroup;
        //serialized private GameController
        [SerializeField] private GameController gameController;
        //serialized bulletfactory
        [SerializeField] private BulletFactory bulletFactory;

        //serialized normal bullet
        [SerializeField] private DataBullet normalBullet;
        //serialized critical bullet
        [SerializeField] private DataBullet criticalBullet;

        private void Awake()
        {
            //set game fps to 60
            Application.targetFrameRate = 60;
        }

        IEnumerator Start()
        {
            //map UI here


            //start the game loop
            yield return CoGameLoop();
        }

        IEnumerator CoGameLoop()
        {
            //setup spaceship skin here
            spaceShip.SetDataShipDisplay(Model.Data.GetRandomSpaceshipSkin());

            //setup enemy group here
            enemyGroup.Setup();

            //cache bullets here
            bulletFactory.InitiateCache(new List<DataBullet>() { normalBullet, criticalBullet });

            yield return null;

            while (enemyGroup.EnemyGroupCompleted == false)
            {
                spaceShip.SetMoveDirection(gameController.InputDirection);
                if (gameController.IsFire)
                {
                    //if a random float is < 0.15
                    if (Random.value < 0.15f)
                    {
                        //spawn critical bullet
                        bulletFactory.SpawnBullet(criticalBullet, spaceShip.gameObject, Vector2.up);
                    }
                    else
                    {
                        //spawn normal bullet
                        bulletFactory.SpawnBullet(normalBullet, spaceShip.gameObject, Vector2.up);
                    }
                }

                yield return null;
            }


            bool victory = enemyGroup.EnemyGroupCompletedCleared;
            if (victory)
            {
                //play victory animation
            }
            else 
            {
                //play gameover animation
                spaceShip.PlayGameover();
            }
        }
        
    }
}