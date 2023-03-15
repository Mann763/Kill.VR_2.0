using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    //declaring properities
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI Highscore_text;
    public Spawner spawner;

    private playerHealth player;

    // initializing the properites
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    //to restart the game
    public void Restart()
    {
        spawner.nextwave = 0;
        player._score = 0;
        this.gameObject.SetActive(false);
    }

    //to hide main menu
    public void MainMenu()
    {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}