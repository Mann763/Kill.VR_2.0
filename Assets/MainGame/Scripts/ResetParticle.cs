using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetParticle : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!particleSystem.isPlaying)
        {
            RestartParticleSystem();
        }
    }

    private void RestartParticleSystem()
    {
        particleSystem.Stop();
        particleSystem.time = 0f;
        particleSystem.Play();
    }
}
