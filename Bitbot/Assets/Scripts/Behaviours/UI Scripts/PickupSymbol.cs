using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSymbol : MonoBehaviour
{
    public float symbolOffset;
    public ItemObject item;
    public GameObject pickupSymbolPrefab;

    private static EventManager em;
    private GameObject ins;

    private void Awake()
    {
        em = FindObjectOfType<EventManager>();
    }

    //Subscriptions
    private void OnEnable()
    {
        em.OnItemTouchEvent += ShowPickupSymbol;
        em.OnItemUntouchEvent += DestroyPickupSymbol;
    }
    //Unsubscribe from events
    private void OnDisable()
    {
        em.OnItemTouchEvent -= ShowPickupSymbol;
        em.OnItemUntouchEvent -= DestroyPickupSymbol;
    }
    //Show pickup symbol. This method is subscribed to OnItemTouch event
    private void ShowPickupSymbol(ItemObject _item)
    {
        if(_item == this.item && !PlayerInventory.instance.touching) //if event's item is the same as this item & no other pickup symbol is displayed
        {
            Vector3 pos = transform.position;
            pos += Vector3.up * symbolOffset;

            ins = Instantiate(pickupSymbolPrefab, pos, Quaternion.Euler(0, 0, 0)); //Instantiate pickup symbol prefab at an offset.
            PlayerInventory.instance.touching = true;
        }
    }
    //Destroy instantiated pickup symbol object.
    private void DestroyPickupSymbol(ItemObject _item)
    {
        if (_item == this.item) //if event's item is the same as this item
        {
            Destroy(ins);
            PlayerInventory.instance.touching = false;
        }
    }
}
