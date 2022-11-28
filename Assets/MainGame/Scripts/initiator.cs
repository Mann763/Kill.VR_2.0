using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initiator : MonoBehaviour
{
    private Spawner _spawn;
    public ParticleSystem[] fire;

    private void Start()
    {
        _spawn = GetComponent<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Collided");
            StartCoroutine(waiteForSeconds());
        }
    }

    IEnumerator waiteForSeconds()
    {
        _spawn.onetimecall = true;
        _spawn.waveCountdown = _spawn.wait1;
        
        fire[0].Play();
        fire[1].Play();

        

        fire[0].GetComponent<AudioSource>().Play();
        fire[1].GetComponent<AudioSource>().Play();

        yield return waiteForSeconds();
    }
}
