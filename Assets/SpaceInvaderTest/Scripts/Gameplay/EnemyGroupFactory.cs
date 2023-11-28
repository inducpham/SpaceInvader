using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class EnemyGroupFactory : MonoBehaviour
    {
        //default enemy data
        [SerializeField] private DataEnemy defaultEnemyData;
        [SerializeField] private bool randomEnemyData;
        [SerializeField] private Enemy templateEnemy;

        //grid data of enemy group
        [SerializeField] private int gridWidth;
        [SerializeField] private int gridHeight;
        [SerializeField] private Vector2 cellSize;

        private void Awake()
        {
            //hide the template enemy
            templateEnemy.gameObject.SetActive(false);
        }

        public List<Enemy> PopulateEnemies()
        {
            templateEnemy.gameObject.SetActive(true);

            //create new list of enemies
            List<Enemy> enemies = new List<Enemy>();

            //calculate total size of enemy group in vector2
            Vector3 totalSize = new Vector3((gridWidth - 1) * cellSize.x, (gridHeight - 1) * cellSize.y, 0);

            //loop through gridHeight
            for (int y = 0; y < gridHeight; y++)
            {
                //loop through gridWidth
                for (int x = 0; x < gridWidth; x++)
                {
                    var data = randomEnemyData ? Model.Data.GetRandomEnemyData() : defaultEnemyData;

                    //instantiate enemy from template enemy
                    Enemy enemy = Instantiate(templateEnemy, transform);
                    //set enemy position to cell position
                    enemy.transform.localPosition = new Vector3(x * cellSize.x, y * cellSize.y, 0) - totalSize / 2;
                    //setup enemy with enemy data
                    enemy.Setup(data);
                    //add enemy to enemies List
                    enemies.Add(enemy);
                }
            }

            //hide the template enemy
            templateEnemy.gameObject.SetActive(false);

            return enemies;

        }
    }
}