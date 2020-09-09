using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSymbol : MonoBehaviour
{
    public float symbolOffset;
    public ItemObject item;
    public GameObject pickupSymbolPrefab;

    private static EventManagerItem emItemPickup;
    private GameObject ins;

    private void Awake()
    {
        emItemPickup = FindObjectOfType<EventManagerItem>();
    }

    //Subscriptions
    private void OnEnable()
    {
        emItemPickup.OnItemTouchEvent += ShowPickupSymbol;
        emItemPickup.OnItemUntouchEvent += DestroyPickupSymbol;
    }
    //Unsubscribe from events
    private void OnDisable()
    {
        emItemPickup.OnItemTouchEvent -= ShowPickupSymbol;
        emItemPickup.OnItemUntouchEvent -= DestroyPickupSymbol;
    }
    //Show pickup symbol. This method is subscribed to OnItemTouch event
    private void ShowPickupSymbol(ItemObject _item)
    {
        if(_item == this.item) //if event's item is the same as this item
        {
            Vector3 pos = transform.position;
            pos += Vector3.up * symbolOffset;

            ins = Instantiate(pickupSymbolPrefab, pos, Quaternion.Euler(0, 0, 0)); //Instantiate pickup symbol prefab at an offset.
        }
    }
    //Destroy instantiated pickup symbol object.
    private void DestroyPickupSymbol(ItemObject _item)
    {
        if (_item == this.item) //if event's item is the same as this item
        {
            Destroy(ins);
        }
    }
}
