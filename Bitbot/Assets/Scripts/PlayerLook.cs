using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private PlayerMovement move;
    void Start()
    {
        move = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        flipSpriteX();
    }

    private void flipSpriteX()
    {
        Vector3 mPos = MousePosition.getMouseWorldPos(0f);
        Vector3 dir = (mPos - transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        move.facingRight = angle > 90 || angle < -90;
    }
}
