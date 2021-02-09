using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraightShot : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifetime = 1;
    public float damage;

    private EventManager em;

    private void Awake()
    {
        em = FindObjectOfType<EventManager>();
    }

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
            if(other.CompareTag("Player Hitbox"))
            {
                em.OnPlayerHurtEventMethod(damage);
            }
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
