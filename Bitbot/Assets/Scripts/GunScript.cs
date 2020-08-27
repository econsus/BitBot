using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private float offset = 2f;
    [SerializeField] private float rateOfFire = 0.1f;
    public GameObject muzzlePrefab, gunEndpoint;

    private Transform player;
    private Camera cam;
    private SpriteRenderer sr;
    private PlayerMovement move;

    private bool canShoot = true;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        cam = Camera.main;
        sr = GetComponentInChildren<SpriteRenderer>();
        move = GetComponentInParent<PlayerMovement>();
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

        HandleShooting(angle);
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

    private void HandleShooting(float angle)
    {
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(SemiAutoShooting(rateOfFire, angle));
        }
    }

    IEnumerator SemiAutoShooting(float t, float angle)
    {
        canShoot = false;

        Vector3 insPos = gunEndpoint.transform.position;
        GameObject temp = Instantiate(muzzlePrefab, insPos, Quaternion.Euler(0, 0, angle));
        yield return new WaitForSeconds(0.2f);
        Destroy(temp);
        yield return new WaitForSeconds(t - 0.2f);
        canShoot = true;
    }
}
