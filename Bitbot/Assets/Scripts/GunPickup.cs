using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    private Transform currentParent, player;
    private GunScript gunScript;
    private BoxCollider2D coll;
    public bool isEquipped;
    void Start()
    {
        currentParent = transform.parent;
        player = GameObject.Find("Player").transform;
        gunScript = GetComponent<GunScript>();
        coll = GetComponent<BoxCollider2D>();

    }
    void Update()
    {
        currentParent = transform.parent;
        isEquipped = currentParent != null;

        gunScript.enabled = isEquipped;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            if(!isEquipped)
            {
                itemPickup();
            }
        }
    }
    private void itemPickup()
    {
        transform.SetParent(player);
    }
}
