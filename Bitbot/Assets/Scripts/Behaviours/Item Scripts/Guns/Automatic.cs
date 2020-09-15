using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : MonoBehaviour, ICanShoot, IReloadable
{
    public RangedWeapon gun;
    private EventManager em;
    private Animator anim;
    private AudioManager am;
    private bool canShoot, isReloading;
    [SerializeField] private int currentBulletCount;

    private void Awake()
    {
        em = FindObjectOfType<EventManager>();
        anim = GetComponentInChildren<Animator>();
        am = FindObjectOfType<AudioManager>();
        currentBulletCount = gun.magazineSize;
    }
    private void OnEnable()
    {
        canShoot = true;
        isReloading = false;
    }

    private void FixedUpdate()
    {
        if (currentBulletCount < 1)
        {
            em.OnGunEmptyEventEventMethod();
        }
    }
    public void Shoot(float angle, GameObject gunEndpoint)
    {
        if (!canShoot || currentBulletCount < 1 || isReloading)
        {
            return;
        }
        StartCoroutine(ShootGun(gun.rateOfFire, angle, gunEndpoint));
    }
    public void Reload()
    {
        if(currentBulletCount != gun.magazineSize && !isReloading)
        {
            StartCoroutine(ReloadGun(gun.reloadTime));
        }
    }

    private IEnumerator ShootGun(float t, float _angle, GameObject _gunEndpoint)
    {
        em.OnGunShotEventMethod();
        canShoot = false;
        if(anim != null)
        {
            anim.SetTrigger("Shoot");
        }
        am.PlaySound(gun.gunShotSound);
        Vector3 insPos = _gunEndpoint.transform.position;
        Instantiate(gun.muzzlePrefab, insPos, Quaternion.Euler(0, 0, _angle));
        Instantiate(gun.bulletPrefab, insPos, Quaternion.Euler(0, 0, _angle));
        currentBulletCount--;
        yield return new WaitForSeconds(t);
        canShoot = true;
    }

    private IEnumerator ReloadGun(float t)
    {
        isReloading = true;
        if (anim != null)
        {
            anim.SetTrigger("Reload");
        }
        am.PlaySound(gun.reloadSound);
        yield return new WaitForSeconds(t);
        currentBulletCount = gun.magazineSize;
        isReloading = false;
    }
}
