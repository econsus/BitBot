using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public ItemObject item;
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
