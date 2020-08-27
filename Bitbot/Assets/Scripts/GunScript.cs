using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private float offset = 2f;
    private Transform player;
    private Camera cam;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        cam = Camera.main;
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

        Vector3 rot = new Vector3(0f, 0f, angle);
        transform.rotation = Quaternion.Euler(rot);

        transform.position = player.position + (offset * dir);
    }
}
