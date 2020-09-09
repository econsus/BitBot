using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerPickup : MonoBehaviour //Big brain time
{
    public delegate void ItemPickup();

    public event ItemPickup OnItemTouchEvent;
    public event ItemPickup OnItemUntouchEvent;
    public event ItemPickup OnItemPickupEvent;

    public void OnItemTouchEventMethod()
    {
        OnItemTouchEvent?.Invoke();
    }
    public void OnItemUntouchEventMethod()
    {
        OnItemUntouchEvent?.Invoke();
    }
    public void OnItemPickupEventMethod()
    {
        OnItemPickupEvent?.Invoke();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
