using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace SpaceInvaderTest
{
    public class ModelPlayer : MonoBehaviour
    {

        private void Start()
        {
            SetLocale(GetLocaleSettingsFromPlayerPref());
        }

        public void SetLocale(string code)
        {
            StartCoroutine(CoSetLocale(code));
        }

        IEnumerator CoSetLocale(string code)
        {
            yield return LocalizationSettings.InitializationOperation;

            //check if locale is available
            var locale = LocalizationSettings.AvailableLocales.Locales.Find((locale) => locale.Identifier.Code == code);

            //set locale to be localizationsettings default locale
            if (locale == null) locale = LocalizationSettings.AvailableLocales.Locales[0];

            LocalizationSettings.SelectedLocale = locale;

            SaveLocaleSettingsToPlayerPref(code);
        }

        void SaveLocaleSettingsToPlayerPref(string code)
        {
            PlayerPrefs.SetString("locale", code);
        }

        string GetLocaleSettingsFromPlayerPref()
        {
            return PlayerPrefs.GetString("locale", "en");
        }

    }
}