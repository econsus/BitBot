﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightShoot : MonoBehaviour
{
    public GameObject player;
    private Vector2 target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        target = new Vector2(player.transform.position.x, player.transform.position.y);

        Destroy(gameObject, 8);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        transform.Translate(speed * Time.deltaTime, 0, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
