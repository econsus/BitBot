using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraightShot : MonoBehaviour
{
    [SerializeField] private float speed = ;
    [SerializeField] private float lifetime = 9f;

    void Start()
    {
        Destroy(gameObject, 8);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hitbox") || other.CompareTag("Solid"))
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
