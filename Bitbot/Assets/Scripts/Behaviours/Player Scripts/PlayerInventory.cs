using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public ItemObject touchedItem;
    private EventManager em;
    private List<GameObject> instantiatedItems;

    private void Awake()
    {
        em = FindObjectOfType<EventManager>();
        instantiatedItems = new List<GameObject>();
    }
    //Subscription(s)
    private void OnEnable()
    {
        em.OnItemPickupEvent += AddItemToPlayerInv;
        em.OnItemPickupEvent += InstantiateEquippedPrefab;
    }
    //Unsubscribe from event(s)
    private void OnDisable()
    {
        em.OnItemPickupEvent -= AddItemToPlayerInv;
        em.OnItemPickupEvent -= InstantiateEquippedPrefab;
    }
    private void Update()
    {
        SetInstantiatedActiveStates();
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
        else //If player inventory is full
        {
            //"Drop" replaced item to the ground by instantiating its prefab
            Instantiate(inventory.GetItem(0).worldPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            //Replace currently equipped item with picked item.
            Destroy(instantiatedItems[0]);
            instantiatedItems.RemoveAt(0);
            inventory.ReplaceItemInInv(_item, 0);
        }
    }
    public void InstantiateEquippedPrefab(ItemObject _item)
    {
        GameObject ins = Instantiate(_item.equippedPrefab, transform);
        ins.SetActive(false);
        instantiatedItems.Insert(0, ins);
    }
    private void SetInstantiatedActiveStates()
    {
        for(int i = 0; i < instantiatedItems.Count; i++)
        {
            if(i == 0)
            {
                instantiatedItems[i].SetActive(true);
            }
            else
            {
                instantiatedItems[i].SetActive(false);
            }
        }
    }
    //Clear inventory on application quit.
    private void OnApplicationQuit() 
    {
        inventory.ClearInventory();
    }
}
