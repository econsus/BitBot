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
        if(playerInv.itemList.Count != 0) //If player inventory is not empty
        {
            DisplayEquipped(playerInv.GetItem(0)); //Display first item in player inventory
        }
        else 
        {
            displayImage.enabled = false;
        }
    }
    //Display item's hud sprite from the scriptable object
    private void DisplayEquipped(ItemObject equipped)
    {
        displayImage.enabled = true;
        displayImage.sprite = equipped.hudSprite;
    }
}
