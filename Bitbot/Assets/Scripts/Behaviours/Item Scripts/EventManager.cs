﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour //Big brain time
{
    //Item Events

    public delegate void ItemPickup(ItemObject item);

    public event ItemPickup OnItemTouchEvent;
    public event ItemPickup OnItemUntouchEvent;
    public event ItemPickup OnItemPickupEvent;

    public void OnItemTouchEventMethod(ItemObject _item)
    {
        OnItemTouchEvent?.Invoke(_item);
    }
    public void OnItemUntouchEventMethod(ItemObject _item)
    {
        OnItemUntouchEvent?.Invoke(_item);
    }
    public void OnItemPickupEventMethod(ItemObject _item)
    {
        OnItemPickupEvent?.Invoke(_item);
    }
    //--------------------------------------------------------//
    public delegate void ItemEquipped(PlayerInventory playerInv);

    public event ItemEquipped OnItemDropEvent;
    public event ItemEquipped OnItemSwitchEvent;
    public void OnItemSwitchEventMethod(PlayerInventory _playerInv)
    {
        OnItemSwitchEvent?.Invoke(_playerInv);
    }
    public void OnItemDropEventMethod(PlayerInventory _playerInv)
    {
        OnItemDropEvent?.Invoke(_playerInv);
    }
    //--------------------------------------------------------//
    public delegate void ItemUse();

    public event ItemUse OnItemShotEvent;
    public void OnItemShotEventMethod()
    {
        OnItemShotEvent?.Invoke();
    }
    
    //-------------------------------------------------------------------------------------------------------------------//

    //-------------------------------------------------------------------------------------------------------------------//
    //TODO:
    //Item Switch Events
    //Item Drop Events
}
