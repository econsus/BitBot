﻿using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Item Events

    public delegate void ItemPickup(ItemObject item);

    public event ItemPickup OnItemTouchEvent;
    public event ItemPickup OnItemUntouchEvent;
    public event ItemPickup OnItemPickupEvent;

    public void OnItemTouchEventMethod(ItemObject item)
    {
        OnItemTouchEvent?.Invoke(item);
    }
    public void OnItemUntouchEventMethod(ItemObject item)
    {
        OnItemUntouchEvent?.Invoke(item);
    }
    public void OnItemPickupEventMethod(ItemObject item)
    {
        OnItemPickupEvent?.Invoke(item);
    }
    //--------------------------------------------------------//
    public delegate void ItemEquipped(PlayerInventory playerInv);

    public event ItemEquipped OnItemDropEvent;
    public event ItemEquipped OnItemSwitchEvent;
    public void OnItemSwitchEventMethod(PlayerInventory playerInv)
    {
        OnItemSwitchEvent?.Invoke(playerInv);
    }
    public void OnItemDropEventMethod(PlayerInventory playerInv)
    {
        OnItemDropEvent?.Invoke(playerInv);
    }
    //--------------------------------------------------------//
    public delegate void ItemUse();

    public event ItemUse OnGunShotEvent;
    public event ItemUse OnGunEmptyEvent;
    public event ItemUse OnGunReloadEvent;
    public void OnGunShotEventMethod()
    {
        OnGunShotEvent?.Invoke();
    }
    public void OnGunEmptyEventEventMethod()
    {
        OnGunEmptyEvent?.Invoke();
    }
    public void OnGunReloadEventEventMethod()
    {
        OnGunReloadEvent?.Invoke();
    }

    //-------------------------------------------------------------------------------------------------------------------//
    public delegate void PlayerPosition(Vector2 dir, float multiplier);

    public event PlayerPosition OnKnockedBackEvent;

    public void OnKnockedBackEventMethod(Vector2 dir, float multiplier)
    {
        OnKnockedBackEvent?.Invoke(dir, multiplier);
    }
    //-------------------------------------------------------------------------------------------------------------------//
    public delegate void PlayerInput(KeyCode kcode);

    public event PlayerInput OnDoubleTapEvent;

    public void OnDoubleTapEventMethod(KeyCode kcode)
    {
        OnDoubleTapEvent?.Invoke(kcode);
    }
    //-------------------------------------------------------------------------------------------------------------------//
    public delegate void CameraShake(float intensity, float time);

    public event CameraShake OnShakeCameraEvent;

    public void OnShakeCameraEventMethod(float intensity, float time)
    {
        OnShakeCameraEvent?.Invoke(intensity, time);
    }
    //-------------------------------------------------------------------------------------------------------------------//
    public delegate void PlayerHurt(float amount);

    public event PlayerHurt OnPlayerHurtEvent;

    public void OnPlayerHurtEventMethod(float amount)
    {
        OnPlayerHurtEvent?.Invoke(amount);
    }
}
