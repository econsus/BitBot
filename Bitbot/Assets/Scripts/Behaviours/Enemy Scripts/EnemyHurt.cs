using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    private AudioManager am;
    private EnemyChase ec;
    public bool contact = false;
    void Start()
    {
        am = FindObjectOfType<AudioManager>();
        ec = GetComponentInParent<EnemyChase>();
    }

    void Update()
    {
        if (contact)
        {
            StartCoroutine(Pause());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player Projectile"))
        {
            contact = true;
        }
    }

    IEnumerator Pause()
    {
        contact = false;
        ec.enabled = false;
        am.PlaySound("Player Hit");
        yield return new WaitForSecondsRealtime(0.15f);
        ec.enabled = true;
    }
}
