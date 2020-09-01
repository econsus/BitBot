using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private PlayerMovement move;
    public bool contact = false;
    void Start()
    {
        move = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(contact)
        {
            StartCoroutine(Pause());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy Projectile"))
        {
            contact = true;
            Debug.Log("CONTACT");
        }
    }

    IEnumerator Pause()
    {
        contact = false;
        Time.timeScale = 0.01f;
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 1f;
    }
}
