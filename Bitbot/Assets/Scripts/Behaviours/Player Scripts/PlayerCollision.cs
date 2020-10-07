using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Space]

    [Header("Radius")]
    public float colliderRadius;

    [Header("Offsets")]
    [SerializeField] private Vector2 bottomOffset;
    [Space]
    [SerializeField] private Vector2 leftOffset = new Vector2();
    [SerializeField] private Vector2 leftOffset_flipped = new Vector2();
    [SerializeField] private Vector2 rightOffset = new Vector2();
    [SerializeField] private Vector2 rightOffset_flipped = new Vector2();

    [Space]

    [Header("Extras")]
    public Color colliderColor = Color.blue;
    public LayerMask groundLayer;

    private PlayerStates ps;
    private Vector2 appliedLeftOffset, appliedRightOffset;

    private void Awake()
    {
        ps = GetComponent<PlayerStates>();
    }

    void FixedUpdate()
    {
        ApplyFlip();

        ps.onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, colliderRadius, groundLayer);

        ps.onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + appliedLeftOffset, colliderRadius, groundLayer);
        ps.onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + appliedRightOffset, colliderRadius, groundLayer);

        ps.onWall = ps.onLeftWall || ps.onRightWall;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = colliderColor;

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, colliderRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + appliedLeftOffset, colliderRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + appliedRightOffset, colliderRadius);
    }

    private void ApplyFlip()
    {
        //if(ps.isWallSliding)
        //{
        //    return;
        //}
        if(!ps.facingLeft)
        {
            if (bottomOffset.x < 0)
            {
                FlipBottomOffsetX();
            }
            if(appliedLeftOffset != leftOffset)
            {
                appliedLeftOffset = leftOffset;
            }
            if(appliedRightOffset != rightOffset)
            {
                appliedRightOffset = rightOffset;
            }
        }
        else
        {
            if (bottomOffset.x > 0)
            {
                FlipBottomOffsetX();
            }
            if(appliedLeftOffset != leftOffset_flipped)
            {
                appliedLeftOffset = leftOffset_flipped;
            }
            if(appliedRightOffset != rightOffset_flipped)
            {
                appliedRightOffset = rightOffset_flipped;
            }
        }
    }
    private void FlipBottomOffsetX()
    {
        bottomOffset = new Vector2(-bottomOffset.x, bottomOffset.y);
    }
}
