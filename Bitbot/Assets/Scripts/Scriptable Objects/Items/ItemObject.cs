using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject worldPrefab, equippedPrefab;
    public Sprite hudSprite;
    public ItemType type;
    [TextArea(15, 10)]
    public string description;
}
