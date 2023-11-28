using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class UIGameover : MonoBehaviour
    {
        [SerializeField] private GameObject groupVictory;
        [SerializeField] private GameObject groupDefeat;
        [SerializeField] private UnityEngine.UI.Text textScore;
        [SerializeField] private UnityEngine.UI.Button buttonReplay;
        [SerializeField] private UnityEngine.UI.Button buttonBackToMain;


        private bool showing;

        private void Start()
        {
            buttonReplay.onClick.AddListener(Model.Scene.LoadGameplayScene);
            buttonBackToMain.onClick.AddListener(Model.Scene.LoadMainmenuScene);

            if (showing == false) gameObject.SetActive(false);            
        }

        void Show()
        {
            showing = true;
            gameObject.SetActive(true);
        }

        public void ShowDefeat(int score)
        {
            Show();
            groupVictory.SetActive(false);
            groupDefeat.SetActive(true);

            textScore.text = score.ToString();
        }

        public void ShowVictory(int score)
        {
            Show();
            groupVictory.SetActive(true);
            groupDefeat.SetActive(false);

            textScore.text = score.ToString();
        }
    }
}