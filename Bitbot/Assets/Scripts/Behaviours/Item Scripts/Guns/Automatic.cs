using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : MonoBehaviour, ICanShoot
{
    public RangedWeapon gun;
    private bool canShoot;

    private void OnEnable()
    {
        canShoot = true;
    }
    public void Shoot(float angle, GameObject gunEndpoint)
    {
        if (!canShoot)
        {
            return;
        }
        StartCoroutine(ShootGun(gun.rateOfFire, angle, gunEndpoint));
    }

    private IEnumerator ShootGun(float t, float _angle, GameObject _gunEndpoint)
    {
        canShoot = false;
        Vector3 insPos = _gunEndpoint.transform.position;
        Instantiate(gun.muzzlePrefab, insPos, Quaternion.Euler(0, 0, _angle));
        Instantiate(gun.bulletPrefab, insPos, Quaternion.Euler(0, 0, _angle));
        yield return new WaitForSeconds(t);
        canShoot = true;
    }
}
