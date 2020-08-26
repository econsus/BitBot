using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Ranged,
    Melee
}

public abstract class WeaponObject : ItemObject
{
    public WeaponType weaponType;
}

