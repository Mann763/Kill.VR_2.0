using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnStart : MonoBehaviour
{
    public GameObject[] waypoints;
    public int speed;
    private GameObject enemy;
    Transform _randomdestinatino;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        enemy.transform.position = Vector3.Slerp(enemy.transform.position, _randomdestinatino.position, speed * Time.deltaTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        _randomdestinatino = waypoints[Random.Range(0, waypoints.Length)].transform;
    }
}
