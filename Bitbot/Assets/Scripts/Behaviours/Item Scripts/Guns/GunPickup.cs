using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject hud;
    private Transform currentParent, player;
    private GunScript gunScript;
    private BoxCollider2D coll;
    public bool isEquipped;
    public bool collide;
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
        hud.SetActive(isEquipped);

        if (Input.GetKeyDown(KeyCode.E)) 
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        
            if (collision.CompareTag("Player") && !collision.isTrigger)
            {
                collide = true;
                if (!isEquipped)
                {                 
                        PickupItem();      
                }
            }
        

    }
    private void PickupItem()
    {
        transform.SetParent(player);
    }
}
