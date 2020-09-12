using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour, ICanShoot
{
    public RangedWeapon gun;
    [SerializeField] private int maxBurst = 3;
    private bool canShoot = true;
    private int currentBurst;

    private void Awake()
    {
        currentBurst = maxBurst;
    }
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
        currentBurst--;
        Vector3 insPos = _gunEndpoint.transform.position;
        Instantiate(gun.muzzlePrefab, insPos, Quaternion.Euler(0, 0, _angle));
        Instantiate(gun.bulletPrefab, insPos, Quaternion.Euler(0, 0, _angle));
        if(currentBurst > 0)
        {
            yield return new WaitForSeconds(t);
            canShoot = true;
        }
        else
        {
            yield return new WaitForSeconds(t + 0.25f);
            canShoot = true;
            currentBurst = maxBurst;
        }
        
    }
}
