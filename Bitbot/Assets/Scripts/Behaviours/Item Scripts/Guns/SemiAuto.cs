using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAuto : MonoBehaviour, ICanShoot
{
    public void Shoot(float angle, Vector3 mPos)
    {
        //start semi auto coroutine
        Debug.Log("Semi Auto Bang Bang");
    }

    //private IEnumerator SemiAutoShooting(float t, float angle, Vector3 mPos)
    //{
    //    canShoot = false;
    //    anim.SetTrigger("Shoot");
    //    am.PlaySound("Gunshot Small");
    //    currentBulletCount--;
    //    Vector3 insPos = gunEndpoint.transform.position;
    //    GameObject muzzleIns = Instantiate(muzzlePrefab, insPos, Quaternion.Euler(0, 0, angle));
    //    Instantiate(bulletPrefab, insPos, Quaternion.Euler(0, 0, angle));
    //    yield return new WaitForSeconds(0.1f);
    //    Destroy(muzzleIns);
    //    yield return new WaitForSeconds(t - 0.2f);
    //    canShoot = true;
    //}
}
