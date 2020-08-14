using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header ("Booleans")]
    public bool onGround;

    [Header("Collision")]
    public float colliderRadius = 0.25f;
    public Vector2 bottomOffset;
    public Color ColliderColor = Color.blue;
    public LayerMask groundLayer;

    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, colliderRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = ColliderColor;

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, colliderRadius);
    }
}
