using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlicker : MonoBehaviour
{
    [Header("Flicker Speed")]
    [SerializeField] private float min = 1f;
    [SerializeField] private float max = 6f;

    private SpriteRenderer sr;
    private bool startFlicker = false;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Flicker(min, max));
    }

    void Update()
    {
        if(startFlicker)
        {
            StartCoroutine(Flicker(min, max));
        }
    }

    IEnumerator Flicker(float _min, float _max)
    {
        startFlicker = false;
        sr.enabled = false;
        yield return new WaitForSeconds(Random.Range(_min, _max));
        sr.enabled = true;
        yield return new WaitForSeconds(Random.Range(_min, _max));
        startFlicker = true;
    }
}
