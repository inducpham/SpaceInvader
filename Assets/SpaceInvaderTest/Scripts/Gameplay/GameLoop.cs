using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceInvaderTest
{
    public class GameLoop : MonoBehaviour
    {



        [Header("Gameplay Elements")]
        //serialized normal bullet
        [SerializeField] private DataBullet normalBullet;
        //serialized critical bullet
        [SerializeField] private DataBullet criticalBullet;

        [Header("Gameplay Components")]
        //serialized private SpaceShip
        [SerializeField] private SpaceShip spaceShip;
        //serialized private EnemyGroup
        [SerializeField] private EnemyGroup enemyGroup;
        //serialized private GameController
        [SerializeField] private GameController gameController;
        //serialized bulletfactory
        [SerializeField] private BulletFactory bulletFactory;
        //serialized private ScoreManager
        [SerializeField] private ScoreManager scoreManager;

        [Header("UI Components")]
        //serialized private UIScoring
        [SerializeField] private UIScoring uiScoring;
        //serialized private UIGameover
        [SerializeField] private UIGameover uiGameover;

        private void Awake()
        {
            //set game fps to 60
            Application.targetFrameRate = 60;
        }

        IEnumerator Start()
        {
            //map gameplay elements here
            enemyGroup.OnEnemyDestroyed += scoreManager.RewardEnemyDestroy;

            //map UI here
            scoreManager.OnScoreUpdated += uiScoring.UpdateScoring;
            enemyGroup.OnEnemyDestroyed += uiScoring.UpdateEnemyDestroyed;

            //start the game loop
            yield return CoGameLoop();

            //play the result here
            bool victory = enemyGroup.EnemyGroupCompletedCleared;
            if (victory) uiGameover.ShowVictory(scoreManager.PlayerScore);
            else uiGameover.ShowDefeat(scoreManager.PlayerScore);
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
            if (victory == false)
            {
                spaceShip.PlayGameover();
            }
        }
        
    }
}