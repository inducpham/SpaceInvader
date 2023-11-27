using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace SpaceInvaderTest
{

    public class ScoreManager : MonoBehaviour
    {

        //callback score updated
        public System.Action<int> OnScoreUpdated = delegate { };

        private int playerScore = 0;
        public int PlayerScore => playerScore;

        private void Start()
        {
            playerScore = 0;
        }

        public void RewardEnemyDestroy(DataEnemy dataEnemy)
        {
            playerScore += dataEnemy.Score;
            OnScoreUpdated(playerScore);
        }
    }

}