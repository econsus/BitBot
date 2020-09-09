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
    public void InsertItemToInv(ItemObject _item, int _index)
    {
        itemList.Insert(_index, _item);
    }
    public void RemoveItemFromInv()
    {
        itemList.RemoveAt(0);
    }
    public void ReplaceItemInInv(ItemObject _item, int _index)
    {
        itemList.RemoveAt(_index);
        InsertItemToInv(_item, _index);
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
