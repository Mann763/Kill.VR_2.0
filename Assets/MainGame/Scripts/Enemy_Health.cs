using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public playerHealth player;
    public Transform centerPoint;

    public float maxHealth;
//    [HideInInspector]
    public float currentHealth;
    public HealthBar healthBar;

    public playerHealth gameOver;

    public int enemy_score;

    public ParticleSystem deathEffect;

    private void LateUpdate()
    {
        transform.LookAt(player.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = GameObject.FindGameObjectWithTag("Center").GetComponent<Transform>();
        this.transform.parent = centerPoint;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {   
        player._score += enemy_score;
        deathEffect.transform.position = this.transform.position;
        deathEffect.Emit(1);
        Destroy(this.gameObject);
    }
}
