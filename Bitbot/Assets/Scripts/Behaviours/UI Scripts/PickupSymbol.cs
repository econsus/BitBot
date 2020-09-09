using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSymbol : MonoBehaviour
{
    public float symbolOffset;
    public GameObject pickup;

    private PlayerInventory playerInv;
    private ItemObject item;
    private GameObject ins;

    private void Start()
    {
        playerInv = GameObject.Find("Player").GetComponent<PlayerInventory>();
        item = playerInv.touchedItem;
        playerInv.OnItemTouch += PlayerInv_OnItemTouch;
        playerInv.OnItemLeave += PlayerInv_OnItemLeave;
    }

    private void PlayerInv_OnItemTouch(object sender, PlayerInventory.OnitemTouchEventArgs e)
    {
        Debug.Log("Cok");
        if(e.item == item)
        {
            Debug.Log("Touch");
            ShowPickupSymbol();
        }
    }
    private void PlayerInv_OnItemLeave(object sender, PlayerInventory.OnItemLeaveEventArgs e)
    {
        if (e.item == item)
        {
            DestroyPickupSymbol();
        }
    }

    private void OnDestroy()
    {
        playerInv.OnItemTouch -= PlayerInv_OnItemTouch;
        playerInv.OnItemLeave -= PlayerInv_OnItemLeave;
    }
    private void ShowPickupSymbol()
    {
        Vector3 pos = transform.position;
        pos += Vector3.up * symbolOffset;

        ins = Instantiate(pickup, pos, Quaternion.Euler(0, 0, 0));
    }

    private void DestroyPickupSymbol()
    {
        Destroy(ins);
    }
}
