using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public float currentHealth;
    
    public float maxHealth;

    public ProgressBarPro healthBar;

    private GameOver gameOver;

    [HideInInspector]
    public int _score;
    [HideInInspector]
    public int _highscore = 0;


    void Start()
    {
        currentHealth = maxHealth;
        gameOver = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOver>();
        gameOver.gameObject.SetActive(false);
    }

    void Update()
    {
        UpdateHealth();
        UpdateScore();
    }

    public void TakeDamage(int amount)
    {
        if(currentHealth >= 0)
        {
            currentHealth -= amount;
            UpdateHealth();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Dead");
        Time.timeScale = 0;
        gameOver.gameObject.SetActive(true);
    }

    void UpdateHealth()
    {
        healthBar.SetValue(currentHealth, maxHealth);
    }


    void UpdateScore()
    {
        gameOver.score_text.text = _score.ToString();

        if (_score > _highscore)
        {
            _highscore = _score;
            PlayerPrefs.SetInt("Highscore", _highscore);
            gameOver.Highscore_text.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }


}
