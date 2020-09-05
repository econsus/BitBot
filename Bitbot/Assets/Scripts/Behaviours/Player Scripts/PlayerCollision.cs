using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header ("Booleans")]
    public bool onGround;
    public bool onWall;
    public bool onLeftWall;
    public bool onRightWall;


    [Header("Box Collider")]
    public Vector2 colliderSize;
    private static float colliderAngle = 0f;

    [Header("Circle Collider")]
    public float colliderRadius;

    [Header("Offsets")]
    public Vector2 bottomOffset;
    public Vector2 leftOffset;
    public Vector2 rightOffset;

    [Header("Extras")]
    public Color colliderColor = Color.blue;
    public LayerMask groundLayer;

    void Update()
    {
        onGround = Physics2D.OverlapBox((Vector2)transform.position + bottomOffset, colliderSize, colliderAngle, groundLayer);

        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, colliderRadius, groundLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, colliderRadius, groundLayer);

        onWall =  onLeftWall || onRightWall;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = colliderColor;

        Gizmos.DrawWireCube((Vector2)transform.position + bottomOffset, colliderSize);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, colliderRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, colliderRadius);
    }

    public void FlipBottomOffsetX()
    {
        bottomOffset = new Vector2(-bottomOffset.x, bottomOffset.y);
    }
}
