using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu_panel;
    public GameObject settings_panel;

    void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void SettingsEnable()
    {
        menu_panel.SetActive(false);
        settings_panel.SetActive(true);
    }

    void SettingsDisable()
    {
        menu_panel.SetActive(true);
        settings_panel.SetActive(false);
    }

    void Quit()
    {
        Application.Quit();
    }
}
