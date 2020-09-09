using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    public InventoryObject playerInv;
    private Image displayImage;
    void Start()
    {
        displayImage = GetComponent<Image>();
    }

    void Update()
    {
        if(playerInv.itemList.Count != 0)
        {
            DisplayEquipped(playerInv.GetItem(0));
        }
        else
        {
            displayImage.enabled = false;
        }
    }

    private void DisplayEquipped(ItemObject equipped)
    {
        displayImage.enabled = true;
        displayImage.sprite = equipped.hudSprite;
    }
}
