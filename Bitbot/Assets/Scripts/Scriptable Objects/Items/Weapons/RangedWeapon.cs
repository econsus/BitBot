using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FiringMode
{
    Semi,
    Automatic,
    Mixed
}
[CreateAssetMenu(fileName = "New Ranged Weapon", menuName = "Inventory System/Items/Weapon/Ranged")]
public class RangedWeapon : WeaponObject
{
    public void Awake()
    {
        type = ItemType.Equipment;
        weaponType = WeaponType.Ranged;
    }

    public int magazineSize;
    public float reloadTime;
    public FiringMode firingMode;
    public float rateOfFire;
}
