using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI Highscore_text;
    public Spawner spawner;

    private playerHealth player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Restart()
    {
        spawner.nextwave = 0;
        player._score = 0;
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
