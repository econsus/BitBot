using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private float offset = 2f;
    [SerializeField] private float rateOfFire = 0.1f;
    public GameObject muzzlePrefab, bulletPrefab, gunEndpoint;

    private Transform player;
    private Camera cam;
    private SpriteRenderer sr;
    private PlayerMovement move;
    private Animator anim;

    private bool canShoot = true;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        cam = Camera.main;
        sr = GetComponentInChildren<SpriteRenderer>();
        move = GetComponentInParent<PlayerMovement>();
        anim = GetComponentInChildren<Animator>();
        
    }

    void Update()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        Vector3 mPos = MousePosition.GetMouseWorldPos(0f, cam);
        Vector3 dir = (mPos - player.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        FlipGun();

        Vector3 rot = new Vector3(0f, 0f, angle);
        transform.rotation = Quaternion.Euler(rot);

        transform.position = player.position + (offset * dir);

        HandleShooting(angle, mPos);
    }

    private void FlipGun()
    {
        Transform gunTrans = gunEndpoint.transform;
        Vector3 temp = gunTrans.localPosition;

        if (move.facingLeft)
        {
            sr.flipY = true;
            if(temp.y > 0)
            {
                
                gunTrans.localPosition = new Vector3(temp.x, -temp.y, temp.z);
            }
        }
        else
        {
            sr.flipY = false;
            if (gunTrans.localPosition.y < 0)
            {
                gunTrans.localPosition = new Vector3(temp.x, -temp.y, temp.z);
            }
        }
        
    }

    private void HandleShooting(float angle, Vector3 mPos)
    {
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(SemiAutoShooting(rateOfFire, angle, mPos));
        }
    }

    IEnumerator SemiAutoShooting(float t, float angle, Vector3 mPos)
    {
        canShoot = false;
        anim.SetTrigger("Shoot");
        Vector3 insPos = gunEndpoint.transform.position;
        GameObject muzzleIns = Instantiate(muzzlePrefab, insPos, Quaternion.Euler(0, 0, angle));
        Instantiate(bulletPrefab, insPos, Quaternion.Euler(0, 0, angle));
        yield return new WaitForSeconds(0.1f);
        Destroy(muzzleIns);
        yield return new WaitForSeconds(t - 0.2f);
        canShoot = true;
    }
}
