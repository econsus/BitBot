using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject hud, pickup;
    public float symbolOffset;
    public bool isEquipped;
    public bool collide;

    private GameObject ins;
    private Transform currentParent, player;
    private GunScript gunScript;
    private BoxCollider2D coll;

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

        if (Input.GetKeyDown(KeyCode.E) && collide && !isEquipped) 
        {
            PickupItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            collide = true;
            if(!isEquipped)
            {
                ShowPickupSymbol();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            collide = false;
            HidePickupSymbol();
        }
    }
    private void PickupItem()
    {
        transform.SetParent(player);
        HidePickupSymbol();
    }
    private void ShowPickupSymbol()
    {
        Vector3 pos = transform.position;
        pos += Vector3.up * symbolOffset;

        ins = Instantiate(pickup, pos, Quaternion.Euler(0, 0, 0));
    }
    private void HidePickupSymbol()
    {
        Destroy(ins);
    }
}
