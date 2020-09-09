using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Scriptable Objects/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<ItemObject> itemList;
    public int defaultCapacity;

    public InventoryObject()
    {
        itemList = new List<ItemObject>();
    }
    public void AddItemToInv(ItemObject _item)
    {
        itemList.Add(_item);
    }
    public void RemoveItemFromInv()
    {
        itemList.RemoveAt(0);
    }
    public void ReplaceItemInInv(ItemObject _item)
    {
        itemList.RemoveAt(0);
        itemList.Add(_item);
        itemList.Reverse();
    }
    public void ReverseInv()
    {
        itemList.Reverse();
    }
    public void ClearInventory()
    {
        itemList.Clear();
    }
    public ItemObject GetItem(int i)
    {
        return itemList[i];
    }
}
