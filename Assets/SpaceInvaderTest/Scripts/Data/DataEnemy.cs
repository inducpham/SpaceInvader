using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    //Generate DataEnemy : ScriptableObject with similar code to DataShipDisplay

    [CreateAssetMenu(fileName = "DataEnemy", menuName = "Data/DataEnemy")]
    public class DataEnemy : ScriptableObject
    {
        [SerializeField] private string code;
        [SerializeField] private string fullname;
        [SerializeField] private int hp;
        [SerializeField] private EnemyDisplay enemyDisplay;

        public string Code => code;
        public string Fullname => fullname;
        public EnemyDisplay EnemyDisplay => enemyDisplay;
        public int Hp => hp;
    }
}