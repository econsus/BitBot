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
        Vector2 knockbackDir = CalcDir();
        em.OnKnockedBackEventMethod(knockbackDir, gun.recoilAmount);
    }
    private Vector2 CalcDir()
    {
        Vector3 mPos = MousePosition.GetMouseWorldPos(0f, cam);
        Vector3 tmp = (mPos - player.position).normalized;
        Vector2 dir = new Vector2(-Mathf.Round(tmp.x), -Mathf.Round(tmp.y));
        //Vector2 dir = new Vector2(-tmp.x, -tmp.y);
        Debug.Log("DIR: " + dir);
        return dir;
    }
}
