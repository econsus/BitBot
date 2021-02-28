using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleOnLoad : MonoBehaviour
{
    private ParticleSystem particle;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }
    private void Start()
    {
        particle.Play();
    }
}
