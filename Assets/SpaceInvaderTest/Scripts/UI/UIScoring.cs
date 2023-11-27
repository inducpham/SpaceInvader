using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceInvaderTest
{
    public class UIScoring : MonoBehaviour
    {

        [SerializeField] private UnityEngine.UI.Text textScore;
        [SerializeField] private Animator animatorTextScore;

        [SerializeField] private UnityEngine.UI.Text textEnemyDestroyed;
        [SerializeField] private string templateTextEnemyDestroyed;

        public void UpdateScoring(int score)
        {
            textScore.text = score.ToString();
            animatorTextScore.SetTrigger("update");
        }

        public void UpdateEnemyDestroyed(DataEnemy data)
        {
            textEnemyDestroyed.text = string.Format(templateTextEnemyDestroyed, data.Fullname);
        }
    }
}