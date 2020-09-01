using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private PlayerMovement move;
    private AudioManager am;
    private AnimationScript anim;
    public bool contact = false;
    public float x = 3;
    public float y = 1;
    void Start()
    {
        move = GetComponentInParent<PlayerMovement>();
        anim = FindObjectOfType<AnimationScript>();
        am = FindObjectOfType<AudioManager>();
    }

    void FixedUpdate()
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
        am.PlaySound("Player Hit");
        anim.TriggerAnim("Hurt");
        move.Knockback(x, y);
        move.enabled = false;
        Time.timeScale = 0.01f;
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.25f);
        move.enabled = true;
    }
}
