using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleRecoil : MonoBehaviour
{
    public RangedWeapon gun;
    private EventManager em;
    private Transform player;
    private Camera cam;
    void Awake()
    {
        em = FindObjectOfType<EventManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void OnEnable()
    {
        em.OnGunShotEvent += InvokeKnockbackEvent;
    }
    private void OnDisable()
    {
        em.OnGunShotEvent -= InvokeKnockbackEvent;
    }

    private void InvokeKnockbackEvent()
    {
        Vector3 knockbackDir = CalcDir();
        em.OnKnockedBackEventMethod(knockbackDir, gun.recoilAmount);
    }
    private Vector3 CalcDir()
    {
        Vector3 mPos = MousePosition.GetMouseWorldPos(0f, cam);
        Vector3 dir = (mPos - player.position).normalized;
        return -dir;
    }
}
