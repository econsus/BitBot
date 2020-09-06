using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private PlayerMovement move;
    private Camera cam;
    void Start()
    {
        move = GetComponent<PlayerMovement>();
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

        move.facingLeft = angle > 90 || angle < -90;
    }
}
