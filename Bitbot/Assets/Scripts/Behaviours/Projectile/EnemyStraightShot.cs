using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraightShot : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifetime = 1;

    void OnEnable()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Hitbox") || other.CompareTag("Solid"))
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
