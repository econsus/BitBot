using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header ("Booleans")]
    public bool onGround;
    public bool onWall;
    public bool onLeftWall;
    public bool onRightWall;

    [Space]

    [Header("Box Collider")]
    public Vector2 colliderSize;
    private static float colliderAngle = 0f;

    [Space]

    [Header("Circle Collider")]
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

    private PlayerMovement move;
    private Vector2 appliedLeftOffset, appliedRightOffset;

    private void Awake()
    {
        move = GetComponent<PlayerMovement>();
    }

    void FixedUpdate()
    {
        ApplyFlip();

        onGround = Physics2D.OverlapBox((Vector2)transform.position + bottomOffset, colliderSize, colliderAngle, groundLayer);

        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + appliedLeftOffset, colliderRadius, groundLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + appliedRightOffset, colliderRadius, groundLayer);

        onWall =  onLeftWall || onRightWall;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = colliderColor;

        Gizmos.DrawWireCube((Vector2)transform.position + bottomOffset, colliderSize);
        Gizmos.DrawWireSphere((Vector2)transform.position + appliedLeftOffset, colliderRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + appliedRightOffset, colliderRadius);
    }

    private void ApplyFlip()
    {
        if(move.isWallSliding)
        {
            return;
        }
        if(!move.facingLeft)
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
