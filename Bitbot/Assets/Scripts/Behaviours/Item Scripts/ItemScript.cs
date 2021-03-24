using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public ItemObject item;

    private EventManager em;
    private bool inTrigger = false;
    private void Awake()
    {
        em = FindObjectOfType<EventManager>();
    }
    private void Update()
    {
        if(inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                em.OnItemPickupEventMethod(item);
            }
        }
    }
    private void OnEnable()
    {
        em.OnItemPickupEvent += DestroySelf;
    }

    private void OnDisable()
    {
        em.OnItemPickupEvent -= DestroySelf;
    }
    //Fire OnItemTouch event
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            em.OnItemTouchEventMethod(item);
        }
    }
    //Fire OnItemPickup event
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            em.OnItemTouchEventMethod(item);
            inTrigger = true;
        }
    }
    //Fire OnItemUntouch event
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            em.OnItemUntouchEventMethod(item);
            inTrigger = false;
        }
    }
    //Destroy item's world object;
    private void DestroySelf(ItemObject _item)
    {
        if(_item == this.item)
        {
            Destroy(gameObject);
        }
    }
}
