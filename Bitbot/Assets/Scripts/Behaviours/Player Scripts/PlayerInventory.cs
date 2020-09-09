using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public ItemObject touchedItem;
    private EventManagerItem emItemPickup;

    private void Awake()
    {
        emItemPickup = FindObjectOfType<EventManagerItem>();
    }
    //Subscription(s)
    private void OnEnable()
    {
        emItemPickup.OnItemPickupEvent += AddItemToPlayerInv;
    }
    //Unsubscribe from event(s)
    private void OnDisable()
    {
        emItemPickup.OnItemPickupEvent -= AddItemToPlayerInv;
    }
    /*private void Update()
    {
        if (canPickup)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                item.DestroySelf();
                if (inventory.itemList.Count < inventory.defaultCapacity)
                {
                    //AddItem(touchedItem);
                }
                else
                {
                    //ReplaceItem(touchedItem, inventory.itemList[0]);
                }
            }
        }
        if (inventory.itemList.Count > 1)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchEquipped();
            }
        }
        if (Input.GetKeyDown(KeyCode.G) && inventory.itemList.Count > 0)
        {
            DropItem(inventory.itemList[0]);
        }
    }
    public void SwitchEquipped()
    {
        inventory.ReverseInv();
    }
    public void DropItem(ItemObject _item)
    {
        inventory.RemoveItemFromInv();
    }*/

    //Add/Replace item to player inventory. This method is subscribed to OnItemPickupEvent
    public void AddItemToPlayerInv(ItemObject _item) 
    {
        if (inventory.itemList.Count < inventory.defaultCapacity) //If player inventory is not full
        {
            //insert picked item to player inventory on the first index
            inventory.InsertItemToInv(_item, 0);
        }
        else //If player inventory is ful
        {
            //"Drop" replaced item to the ground by instantiating its prefab
            Instantiate(inventory.GetItem(0).prefab, transform.position, Quaternion.Euler(0, 0, 0)); 
            //Replace currently equipped item with picked item.
            inventory.ReplaceItemInInv(_item, 0);
        }
    }
    //Clear inventory on application quit.
    private void OnApplicationQuit() 
    {
        inventory.ClearInventory();
    }
}
