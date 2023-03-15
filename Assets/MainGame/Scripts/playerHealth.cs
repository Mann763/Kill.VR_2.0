using HurricaneVR.Framework.Core.Player;
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

    public AudioClip _gameoverclip;
    public AudioSource _playersource;
    private fadeing _fading;
    [SerializeField]private GameObject _wastedPng;

    private bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        gameOver = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOver>();
        gameOver.gameObject.SetActive(false);
        _playersource = this.GetComponent<AudioSource>();
        _fading = GameObject.FindWithTag("fader").GetComponent<fadeing>();
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

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Dead");
        isDead = true;

        //Time.timeScale = 0;
        gameOver.gameObject.SetActive(true);
        _playersource.PlayOneShot(_gameoverclip, 1);
        _fading.FadeIn();
        StartCoroutine(ChangeScene());
        StartCoroutine(GameOver());
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

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2.5f);
        _wastedPng.SetActive(true);
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
