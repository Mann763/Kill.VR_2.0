using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class initiator : MonoBehaviour
{
    //properties
    private Spawner _spawn;
    public ParticleSystem[] fire;
    public AudioSource _source;
    
    private int _time = 0;

    //audioclips
    [Header("Audio Clips")]
    [SerializeField] public AudioClip _get_ready;
    public AudioClip _Fight;
    [SerializeField] private AudioClip _Fire;
    [SerializeField] private AudioClip _instructions;

    [HideInInspector]public Transform _button;

    //intilising properties
    private void Start()
    {
        _spawn = GetComponent<Spawner>();
        _source = GetComponent<AudioSource>();
        _button = GameObject.FindGameObjectWithTag("ButtonStand").GetComponent<Transform>();
    }

    //checking collision with player and playing sound
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && _time == 0)
        {
            _time ++;
            Debug.Log("Collided");
            _source.PlayOneShot(_get_ready, 0.5f);
            StartCoroutine(waiteForSeconds());
        }
    }

    //playing fire VFX and sound
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

    public void MoveButtonDown()
    {
        foreach (Collider c in _button.GetComponentsInChildren<Collider>())
        {
            c.enabled = false;
        }
        _button.transform.DOLocalMoveY(-1, 3,false);
        _source.PlayOneShot(_instructions, 1);
    }
}