using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class ModelScene : MonoBehaviour
    {
        [SerializeField] private string sceneMainmenu;
        [SerializeField] private string sceneGameplay;

        public void LoadMainmenuScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneMainmenu);
        }

        public void LoadGameplayScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneGameplay);
        }
    }
}