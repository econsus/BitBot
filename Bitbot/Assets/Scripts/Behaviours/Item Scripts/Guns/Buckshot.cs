using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckshot : MonoBehaviour, ICanShoot, IReloadable
{
    public RangedWeapon gun;
    private EventManager em;
    private Animator anim;
    private AudioManager am;
    private bool canShoot, isReloading;
    [SerializeField] private int currentBulletCount;

    private void Awake()
    {
        currentBulletCount = gun.magazineSize;
        em = FindObjectOfType<EventManager>();
        anim = GetComponentInChildren<Animator>();
        am = FindObjectOfType<AudioManager>();
    }

    private void OnEnable()
    {
        canShoot = true;
        isReloading = false;
    }
    private void Update()
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
        if (currentBulletCount != gun.magazineSize && !isReloading)
        {
            StartCoroutine(ReloadGun(gun.reloadTime));
        }
    }

    private IEnumerator ShootGun(float t, float _angle, GameObject _gunEndpoint)
    {
        em.OnGunShotEventMethod();
        canShoot = false;
        Vector3 insPos = _gunEndpoint.transform.position;
        if (anim != null)
        {
            anim.SetTrigger("Shoot");
        }
        am.PlaySound(gun.gunShotSound);
        for(int i = 0; i < 3; i++)
        {
            float z = Random.Range(_angle - 10f, _angle + 10f);
            Instantiate(gun.muzzlePrefab, insPos, Quaternion.Euler(0, 0, z));
            Instantiate(gun.bulletPrefab, insPos, Quaternion.Euler(0, 0, z));
        }
        currentBulletCount--;
        yield return new WaitForSeconds(t);
        canShoot = true;
    }
    private IEnumerator ReloadGun(float t)
    {
        isReloading = true;
        am.PlaySound(gun.reloadSound);
        yield return new WaitForSeconds(t);
        currentBulletCount = gun.magazineSize;
        isReloading = false;
    }
}
