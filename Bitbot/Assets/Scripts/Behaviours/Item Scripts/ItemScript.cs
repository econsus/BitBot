using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public ItemObject item;

    private EventManagerItem emItemPickup;
    private void Awake()
    {
        emItemPickup = FindObjectOfType<EventManagerItem>();
    }
    private void OnEnable()
    {
        emItemPickup.OnItemPickupEvent += DestroySelf;
    }

    private void OnDisable()
    {
        emItemPickup.OnItemPickupEvent -= DestroySelf;
    }
    //Fire OnItemTouch event
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            emItemPickup.OnItemTouchEventMethod(item);
        }
    }
    //Fire OnItemPickup event
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.CompareTag("Player"))
        {
            emItemPickup.OnItemPickupEventMethod(item);
        }
    }
    //Fire OnItemUntouch event
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            emItemPickup.OnItemUntouchEventMethod(item);
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
