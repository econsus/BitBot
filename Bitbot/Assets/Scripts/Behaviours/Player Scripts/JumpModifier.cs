using UnityEngine;

public class JumpModifier : MonoBehaviour
{
    [Header("Multiplers")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float maxHeight = 5.5f;

    private PlayerMovement move;
    private Rigidbody2D rb;

    void Start()
    {
        move = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < maxHeight && rb.velocity.y != 0)
        {
            ApplyHigh();
        }
        else if (rb.velocity.y > 1 && move.canMove && !Input.GetButton("Jump") || move.isKnockedback && Input.GetButton("Jump"))
        {
            ApplyLow();
        }
    }
    private void ApplyHigh()
    {
        rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }
    private void ApplyLow()
    {
        rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }
}