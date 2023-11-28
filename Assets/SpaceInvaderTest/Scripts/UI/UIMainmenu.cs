using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class UIMainmenu : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button buttonPlay;
        [SerializeField] private UnityEngine.UI.Button buttonLocale;

        [Header("Group Locale")]
        [SerializeField] private GameObject groupLocale;
        [SerializeField] private UnityEngine.UI.Button buttonLocaleEnglish;
        [SerializeField] private UnityEngine.UI.Button buttonLocaleVietnamese;
        [SerializeField] private UnityEngine.UI.Button buttonLocaleBack;


        // Start is called before the first frame update
        void Start()
        {
            buttonPlay.onClick.AddListener(PlayGame);
            buttonLocale.onClick.AddListener(ShowGroupLocale);

            buttonLocaleBack.onClick.AddListener(HideGroupLocale);
            buttonLocaleEnglish.onClick.AddListener(() => ChangeLocale("en"));
            buttonLocaleVietnamese.onClick.AddListener(() => ChangeLocale("vi"));

            groupLocale.SetActive(false);
        }

        void ShowGroupLocale()
        {
            groupLocale.SetActive(true);
        }

        void HideGroupLocale()
        {
            groupLocale.SetActive(false);
        }

        void PlayGame()
        {
            Model.Scene.LoadGameplayScene();
        }

        void ChangeLocale(string locale)
        {
        }

    }
}