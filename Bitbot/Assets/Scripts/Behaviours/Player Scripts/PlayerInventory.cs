using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public event EventHandler<OnitemTouchEventArgs> OnItemTouch;
    public class OnitemTouchEventArgs : EventArgs
    {
        public ItemObject item;
    }
    public event EventHandler<OnItemLeaveEventArgs> OnItemLeave;
    public class OnItemLeaveEventArgs : EventArgs
    {
        public ItemObject item;
    }
    public ItemObject touchedItem;
    private bool canPickup = false;
    private ItemScript item;
    private Camera cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void Update()
    {
        if(canPickup)
        {
            //show symbol
            touchedItem = item.item;
            if(Input.GetKeyDown(KeyCode.E))
            {
                item.DestroySelf();
                if (inventory.itemList.Count < inventory.defaultCapacity)
                {
                    AddItem(touchedItem);
                }
                else
                {
                    ReplaceItem(touchedItem, inventory.itemList[0]);
                }
            }
        }
        if(inventory.itemList.Count > 1)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                SwitchEquipped();
            }
        }
        if(Input.GetKeyDown(KeyCode.G) && inventory.itemList.Count > 0)
        {
            DropItem(inventory.itemList[0]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        item = collision.GetComponent<ItemScript>();
        if(item)
        {
            OnItemTouch?.Invoke(this, new OnitemTouchEventArgs { item = touchedItem});
            canPickup = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        item = collision.GetComponent<ItemScript>();
        if (item)
        {
            OnItemLeave?.Invoke(this, new OnItemLeaveEventArgs { item = touchedItem });
            canPickup = false;
        }
    }
    public void SwitchEquipped()
    {
        inventory.ReverseInv();
    }
    public void DropItem(ItemObject _item)
    {
        InstantiateDropped(_item);
        inventory.RemoveItemFromInv();
    }

    private Vector3 CalcThrow()
    {
        Vector3 mPos = MousePosition.GetMouseWorldPos(0f, cam);
        Vector3 dir = (mPos - transform.position).normalized;

        return dir;
    }
    public void AddItem(ItemObject _item)
    {
        inventory.AddItemToInv(_item);
    }
    public void ReplaceItem(ItemObject _item, ItemObject replaced)
    {
        InstantiateDropped(replaced);
        inventory.ReplaceItemInInv(_item);
    }
    private void InstantiateDropped(ItemObject _item)
    {
        Instantiate(_item.prefab, transform.position, Quaternion.Euler(0, 0, 0));
    }
    private void OnApplicationQuit()
    {
        inventory.ClearInventory();
    }
}
