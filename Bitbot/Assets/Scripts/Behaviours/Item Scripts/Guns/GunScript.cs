//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GunScript : MonoBehaviour
//{
//    [SerializeField] private float offset = 2f;

//    [Header("Stats")]
//    [SerializeField] private FiringMode firingMode;
//    [SerializeField] private float rateOfFire;
//    [SerializeField] private int magSize;
//    [SerializeField] private int currentBulletCount;
//    [SerializeField] private float reloadTime;

//    public GameObject muzzlePrefab, bulletPrefab, gunEndpoint;
//    public RangedWeapon scriptableObject;

//    private Transform player;
//    private Camera cam;
//    private SpriteRenderer sr;
//    private PlayerMovement move;
//    private Animator anim;
//    private AudioManager am;

//    private bool canShoot = true;

//    private void Awake()
//    {
//        firingMode = scriptableObject.firingMode;
//        rateOfFire = scriptableObject.rateOfFire;
//        reloadTime = scriptableObject.reloadTime;
//        magSize = scriptableObject.magazineSize;
//        currentBulletCount = magSize;

//    }
//    void Start()
//    {
//        player = GameObject.Find("Player").transform;
//        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
//        sr = GetComponentInChildren<SpriteRenderer>();
//        move = GetComponentInParent<PlayerMovement>();
//        anim = GetComponentInChildren<Animator>();
//        am = FindObjectOfType<AudioManager>();
//    }

//    void Update()
//    {
//        HandleAiming();
//        if(Input.GetKeyDown(KeyCode.R))
//        {
//            HandleReload();
//        }
//    }

//    private void HandleAiming()
//    {
//        Vector3 mPos = MousePosition.GetMouseWorldPos(0f, cam);
//        Vector3 dir = (mPos - player.position).normalized;

//        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

//        FlipGun();

//        Vector3 rot = new Vector3(0f, 0f, angle);
//        transform.rotation = Quaternion.Euler(rot);

//        transform.position = player.position + (offset * dir);

//        if (firingMode == FiringMode.Semi)
//        {
//            HandleSemiAutoShooting(angle, mPos);
//        }
//        if (firingMode == FiringMode.Automatic)
//        {
//            HandleAutoShooting(angle, mPos);
//        }
//    }

//    private void FlipGun()
//    {
//        Transform gunTrans = gunEndpoint.transform;
//        Vector3 temp = gunTrans.localPosition;

//        if (move.facingLeft)
//        {
//            sr.flipY = true;
//            if(temp.y > 0)
//            {
//                gunTrans.localPosition = new Vector3(temp.x, -temp.y, temp.z);
//            }
//        }
//        else
//        {
//            sr.flipY = false;
//            if (gunTrans.localPosition.y < 0)
//            {
//                gunTrans.localPosition = new Vector3(temp.x, -temp.y, temp.z);
//            }
//        }
//    }

//    private void HandleSemiAutoShooting(float angle, Vector3 mPos)
//    {
//        if(Input.GetMouseButtonDown(0) && canShoot)
//        {
//            if(currentBulletCount > 0)
//            {
//                StartCoroutine(SemiAutoShooting(rateOfFire, angle, mPos));
//            }
//            else
//            {
//                HandleReload();
//            }
//        }
//    }

//    private void HandleAutoShooting(float angle, Vector3 mPos)
//    {
//        if (Input.GetMouseButton(0) && canShoot)
//        {
//            if (currentBulletCount > 0)
//            {
//                StartCoroutine(AutoShooting(rateOfFire, angle, mPos));
//            }
//            else
//            {
//                HandleReload();
//            }
//        }
//    }

//    private void HandleReload()
//    {
//        StartCoroutine(ReloadGun(reloadTime));
//    }

//    IEnumerator SemiAutoShooting(float t, float angle, Vector3 mPos)
//    {
//        canShoot = false;
//        anim.SetTrigger("Shoot");
//        am.PlaySound("Gunshot Small");
//        currentBulletCount--;
//        Vector3 insPos = gunEndpoint.transform.position;
//        GameObject muzzleIns = Instantiate(muzzlePrefab, insPos, Quaternion.Euler(0, 0, angle));
//        Instantiate(bulletPrefab, insPos, Quaternion.Euler(0, 0, angle));
//        yield return new WaitForSeconds(0.1f);
//        Destroy(muzzleIns);
//        yield return new WaitForSeconds(t - 0.2f);
//        canShoot = true;
//    }

//    IEnumerator AutoShooting(float t, float angle, Vector3 mPos)
//    {
//        am.PlaySound("Gunshot Small");
//        canShoot = false;
//        currentBulletCount--;
//        Vector3 insPos = gunEndpoint.transform.position;
//        GameObject muzzleIns = Instantiate(muzzlePrefab, insPos, Quaternion.Euler(0, 0, angle));
//        Instantiate(bulletPrefab, insPos, Quaternion.Euler(0, 0, angle));
//        yield return new WaitForSeconds(t - 0.2f);
//        Destroy(muzzleIns);
//        canShoot = true;

//    }

//    IEnumerator ReloadGun(float t)
//    {
//        canShoot = false;
//        am.PlaySound("Reload 1");
//        yield return new WaitForSeconds(t);
//        currentBulletCount = magSize;
//        canShoot = true;

//    }
//}
