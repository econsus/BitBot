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
    public void RemoveItemFromInv(int _index)
    {
        itemList.RemoveAt(_index);
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
