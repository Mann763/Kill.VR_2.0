using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    //properties of the enemy
    public playerHealth player;
    public GameObject[] centerPoint;
    private int current_Point;

    public float maxHealth;

    [HideInInspector] public float currentHealth;
    public HealthBar healthBar;

    public playerHealth gameOver;

    public int enemy_score;

    public ParticleSystem deathEffect;

    //updating how enemy looks at player
    private void LateUpdate()
    {
        transform.LookAt(player.transform.position);
    }

    // initializing the properties
    void Start()
    {
        centerPoint = GameObject.FindGameObjectsWithTag("Centers");
        current_Point = Random.Range(0,centerPoint.Length);

        this.transform.parent = centerPoint[current_Point].transform;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
    }

    // taking damage when hit 
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        // dying when health is 0
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
