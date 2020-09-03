using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header ("Booleans")]
    public bool onGround;

    [Header("Collision")]
    public Vector2 colliderSize;
    public Vector2 bottomOffset;
    public Color colliderColor = Color.blue;
    public LayerMask groundLayer;
    private static float colliderAngle = 0f;

    void Update()
    {
        onGround = Physics2D.OverlapBox((Vector2)transform.position + bottomOffset, colliderSize, colliderAngle, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = colliderColor;

        Gizmos.DrawWireCube((Vector2)transform.position + bottomOffset, colliderSize);
    }
}
