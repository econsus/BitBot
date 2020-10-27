using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private PlayerStates ps;
    private Camera cam;
    void Start()
    {
        ps = GetComponent<PlayerStates>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        FlipSpriteX();
    }

    private void FlipSpriteX()
    {
        Vector3 mPos = MousePosition.GetMouseWorldPos(0f, cam);
        Vector3 dir = (mPos - transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        ps.facingLeft = angle > 90 || angle < -90;
    }
}
