using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour, ICanShoot, IReloadable
{
    public RangedWeapon gun;
    private EventManager em;
    private Animator anim;
    private AudioManager am;
    [SerializeField] private int maxBurst = 3;
    private bool canShoot, isReloading;
    [SerializeField] private int currentBulletCount;
    private int currentBurst;

    private void Awake()
    {
        em = FindObjectOfType<EventManager>();
        anim = GetComponentInChildren<Animator>();
        am = FindObjectOfType<AudioManager>();

        currentBulletCount = gun.magazineSize;
        currentBurst = maxBurst;
    }
    private void OnEnable()
    {
        canShoot = true;
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
        //Play Reload Sound
        StartCoroutine(ReloadGun(gun.reloadTime));
    }

    private IEnumerator ShootGun(float t, float _angle, GameObject _gunEndpoint)
    {
        em.OnGunShotEventMethod();
        canShoot = false;
        currentBurst--;
        Vector3 insPos = _gunEndpoint.transform.position;
        float z = Random.Range(_angle - 5f, _angle + 5f);
        Instantiate(gun.muzzlePrefab, insPos, Quaternion.Euler(0, 0, _angle));
        Instantiate(gun.bulletPrefab, insPos, Quaternion.Euler(0, 0, z));
        currentBulletCount--;
        if (anim != null)
        {
            anim.SetTrigger("Shoot");
        }
        am.PlaySound(gun.gunShotSound);
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
    private IEnumerator ReloadGun(float t)
    {
        isReloading = true;
        am.PlaySound(gun.reloadSound);
        yield return new WaitForSeconds(t);
        currentBulletCount = gun.magazineSize;
        isReloading = false;
    }
}
