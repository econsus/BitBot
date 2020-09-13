using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Weapon", menuName = "Scriptable Objects/Items/Weapon/Ranged")]
public class RangedWeapon : WeaponObject
{
    public void Awake()
    {
        type = ItemType.Equipment;
        weaponType = WeaponType.Ranged;
    }

    public int magazineSize;
    public float projectileVelocity;
    public float reloadTime;
    public float rateOfFire;
    public float recoilAmount;
    public GameObject muzzlePrefab, bulletPrefab;
    public AudioClip gunShotSound, reloadSound;
}
