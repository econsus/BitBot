using UnityEngine;

public class JumpModifier : MonoBehaviour
{
    [Header("Multiplers")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private PlayerMovement move;
    private Rigidbody2D rb;
    void Start()
    {
        move = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < 4 && rb.velocity.y != 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 1 && move.canMove)
        {
            if(!Input.GetButton("Jump"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        if(rb.velocity.y > 1 && !move.canMove)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}