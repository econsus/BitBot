using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSymbol : MonoBehaviour
{
    public float symbolOffset;
    public GameObject pickupSymbolPrefab;

    private EventManagerPickup eventManagerPickup;
    private GameObject ins;

    private void Awake()
    {
        eventManagerPickup = FindObjectOfType<EventManagerPickup>();
    }

    private void OnEnable()
    {
        eventManagerPickup.OnItemTouchEvent += ShowPickupSymbol;
        eventManagerPickup.OnItemUntouchEvent += DestroyPickupSymbol;
    }
    private void OnDisable()
    {
        eventManagerPickup.OnItemTouchEvent -= ShowPickupSymbol;
        eventManagerPickup.OnItemUntouchEvent -= DestroyPickupSymbol;
    }
    private void ShowPickupSymbol()
    {
        Vector3 pos = transform.position;
        pos += Vector3.up * symbolOffset;

        ins = Instantiate(pickupSymbolPrefab, pos, Quaternion.Euler(0, 0, 0));
    }

    private void DestroyPickupSymbol()
    {
        Destroy(ins);
    }
}
