using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    public int wait1;
    public enum spawnstate { SPWANING, WAITING, COUNTING };

    [System.Serializable]
    public class wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }

    public Transform[] spawnPoints;

    public wave[] waves;
    [HideInInspector]
    public int nextwave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown = 0f;

    //public float levelnameCountdown = 3f;

    private float searchCountdown = 1f;

    private spawnstate state = spawnstate.COUNTING;

    public bool onetimecall;

    public GameObject GameOver;

    private initiator _Initiator;

    private void Awake()
    {
        _Initiator = GetComponent<initiator>();
    }

    private void Update()
    {

        if (state == spawnstate.WAITING)
        {
            if (!EmemyisAlive())
            {
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0 && onetimecall == true)
        {
            if (state != spawnstate.SPWANING)
            {
                StartCoroutine(SpawnWave(waves[nextwave]));
                onetimecall = false;
                _Initiator._source.PlayOneShot(_Initiator._Fight, 0.7f);
            }
        }
        else
        {
            if(waveCountdown >= 0)
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = spawnstate.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextwave + 1 > waves.Length - 1)
        {
            Debug.Log("Waves Completed");
            
            GameOver.SetActive(true);
            _Initiator._source.PlayOneShot(_Initiator._get_ready, 1);
            StartCoroutine(RestartWait());
        }
        else
        {
            nextwave++;
        }
    }

    bool EmemyisAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                Debug.Log("Searching Enemy : Completed");
                waveCountdown = timeBetweenWaves;
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = spawnstate.SPWANING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy[Random.Range(0,_wave.enemy.Length)]);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = spawnstate.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Enemy" + _enemy.name);
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn Points Added");
        }

        Transform sp = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, sp.position, sp.rotation);
    }

    IEnumerator RestartWait()
    {
        yield return new WaitForSeconds(10f);
        GameOver.GetComponent<GameOver>().Restart();
    }
}