using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleShooting : MonoBehaviour
{
    public GameObject gunEndpoint;
    [SerializeField] private float offset = 2f;

    private float angle;

    private EventManager em;
    private SpriteRenderer sr;
    private Transform player;
    private Camera cam;

    private void Awake()
    {
        em = FindObjectOfType<EventManager>();
        player = GameObject.Find("Player").transform;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        em.OnGunShotEvent += ShootGun;
    }
    private void OnDisable()
    {
        em.OnGunShotEvent -= ShootGun;
    }
    void Update()
    {
        HandleAiming();
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            em.OnGunShotEventMethod();
        }
    }

    private void ShootGun()
    {
        ICanShoot shootable = GetComponent<ICanShoot>();
        shootable?.Shoot(angle, gunEndpoint);
    }
    private void HandleAiming()
    {
        Vector3 mPos = MousePosition.GetMouseWorldPos(0f, cam);
        Vector3 dir = (mPos - player.position).normalized;

        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        FlipGun();

        Vector3 rot = new Vector3(0f, 0f, angle);
        transform.rotation = Quaternion.Euler(rot);

        transform.position = player.position + (offset * dir);
    }

    private void FlipGun()
    {
        Transform gunTrans = gunEndpoint.transform;
        Vector3 temp = gunTrans.localPosition;

        if (angle > 90 || angle < -90)
        {
            sr.flipY = true;
            if (temp.y > 0)
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
}
