using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckshot : MonoBehaviour, ICanShoot
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
        for(int i = 0; i < 3; i++)
        {
            float z = Random.Range(_angle - 10f, _angle + 10f);
            Instantiate(gun.muzzlePrefab, insPos, Quaternion.Euler(0, 0, z));
            Instantiate(gun.bulletPrefab, insPos, Quaternion.Euler(0, 0, z));
        }
        yield return new WaitForSeconds(t);
        canShoot = true;
    }
}
