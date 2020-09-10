using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAuto : MonoBehaviour, ICanShoot
{
    public RangedWeapon gun;
    private bool canShoot = true;
    public void Shoot(float angle, GameObject gunEndpoint)
    {
        //start semi auto coroutine
        if(!canShoot)
        {
            return;
        }
        StartCoroutine(SemiAutoShooting(gun.rateOfFire, angle, gunEndpoint));
    }

    private IEnumerator SemiAutoShooting(float t, float _angle, GameObject _gunEndpoint)
    {
        canShoot = false;
        Vector3 insPos = _gunEndpoint.transform.position;
        GameObject muzzleIns = Instantiate(gun.muzzlePrefab, insPos, Quaternion.Euler(0, 0, _angle));
        Instantiate(gun.bulletPrefab, insPos, Quaternion.Euler(0, 0, _angle));
        yield return new WaitForSeconds(0.1f);
        Destroy(muzzleIns);
        yield return new WaitForSeconds(t - 0.2f);
        canShoot = true;
    }
}
