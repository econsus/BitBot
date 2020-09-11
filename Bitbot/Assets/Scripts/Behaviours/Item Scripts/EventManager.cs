using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour //Big brain time
{
    //Item Pickup Events

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

    //-------------------------------------------------------------------------------------------------------------------//

    //Item Shot Event(s)

    public delegate void ItemShot();

    public event ItemShot OnItemShot;

    public void OnItemShotEventMethod()
    {
        OnItemShot?.Invoke();
    }



    //public event ItemEquipped OnItemEquipEvent; //Rencanane lek event iki fired ngko player njupuk item scriptable object-
                                           //senjata kanggo menentukan senjata opo iki. Terus instantiate prefab-
                                           //senjata seng enek script e attack (Duduk seng world item).
    //-------------------------------------------------------------------------------------------------------------------//
    //TODO:
    //Item Switch Events
    //Item Drop Events
}
