using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public static PlayerInventory instance;
    public bool touching = false;
    public ItemObject touchedItem;
    private PlayerMovement move;
    private EventManager em;
    private AudioManager am;
    private List<GameObject> instantiatedItems;

    private void Awake()
    {
        em = FindObjectOfType<EventManager>();
        am = FindObjectOfType<AudioManager>();
        instance = this;
        instantiatedItems = new List<GameObject>();
        move = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    //Subscription(s)
    private void OnEnable()
    {
        em.OnItemPickupEvent += AddItemToPlayerInv;
        em.OnItemPickupEvent += InstantiateEquippedPrefab;
        //em.OnItemSwitchEvent += SwitchWeapon;
        em.OnItemDropEvent += DropItem;
    }
    //Unsubscribe from event(s)
    private void OnDisable()
    {
        em.OnItemPickupEvent -= AddItemToPlayerInv;
        em.OnItemPickupEvent -= InstantiateEquippedPrefab;
        //em.OnItemSwitchEvent -= SwitchWeapon;
        em.OnItemDropEvent -= DropItem;
    }
    private void FixedUpdate()
    {
        SwitchCheck();
        DropCheck();
        SetInstantiatedActiveStates();
    }
    //Add/Replace item to player inventory. This method is subscribed to OnItemPickupEvent
    public void AddItemToPlayerInv(ItemObject _item) 
    {
        am.PlaySound(_item.pickupSound);
        if (inventory.itemList.Count < inventory.defaultCapacity) //If player inventory is not full
        {
            //insert picked item to player inventory on the first index
            inventory.InsertItemToInv(_item, 0);
        }
        else //If player inventory is full
        {
            //"Drop" replaced item to the ground by instantiating its prefab
            DropItem(this);
            //Replace currently equipped item with picked item.
            inventory.InsertItemToInv(_item, 0);
        }
    }
    private void SwitchWeapon()
    {
        inventory.itemList.Reverse();
        instantiatedItems.Reverse();
    }
    public void InstantiateEquippedPrefab(ItemObject _item)
    {
        GameObject ins = Instantiate(_item.equippedPrefab, transform);
        ins.SetActive(false);
        instantiatedItems.Insert(0, ins);
    }
    private void SwitchCheck()
    {
        if (inventory.itemList.Count > 0 && Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
    }
    private void DropCheck()
    {
        if(inventory.itemList.Count > 0 && Input.GetKeyDown(KeyCode.G))
        {
            em.OnItemDropEventMethod(this);
        }
    }
    private void DropItem(PlayerInventory p)
    {
        Vector3 offset = p.move.facingLeft ? Vector3.left * 2f : Vector3.right * 2f;
        GameObject ins = Instantiate(p.inventory.GetItem(0).worldPrefab, p.transform.position + offset, Quaternion.Euler(0, 0, 0));
        ins.GetComponentInChildren<SpriteRenderer>().flipX = p.move.facingLeft;
        Destroy(p.instantiatedItems[0]);
        p.instantiatedItems.RemoveAt(0);
        p.inventory.RemoveItemFromInv(0);
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
