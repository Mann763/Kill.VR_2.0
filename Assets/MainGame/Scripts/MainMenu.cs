using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using TMPro;

namespace HurricaneVR.Framework.Core.Player
{
    public class MainMenu : MonoBehaviour
    {
        public HVRScreenFade ScreenFade;

        public GameObject menu_panel;
        public GameObject settings_panel;
        public TextMeshProUGUI Highscore_text;

        public void StartFade()
        {
            ScreenFade.Fade(1, 1);
        }

        public void FadeOut()
        {
            ScreenFade.Fade(0,1);
        }
        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Highscore_text.text = PlayerPrefs.GetInt("Highscore").ToString();
        }

        public void SettingsEnable()
        {
            menu_panel.SetActive(false);
            settings_panel.SetActive(true);
        }

        public void SettingsDisable()
        {
            menu_panel.SetActive(true);
            settings_panel.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}

