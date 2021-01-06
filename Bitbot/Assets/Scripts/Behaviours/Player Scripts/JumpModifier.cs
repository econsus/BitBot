using UnityEngine;

public class JumpModifier : MonoBehaviour
{
    [Header("Multiplers")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpThreshold = 8.5f;

    private bool heldJump = false;
    private PlayerStates ps;
    private Rigidbody2D rb;

    void Start()
    {
        ps = GetComponent<PlayerStates>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!Input.GetButton("Jump"))
        {
            heldJump = false;
        }
        else
        {
            heldJump = true;
        }
    }
    void FixedUpdate()
    {
        if (rb.velocity.y < jumpThreshold && rb.velocity.y != 0 ||
            ps.isKnockedback && rb.velocity.y > 0 && !ps.wasOnGround && heldJump)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !heldJump ||
            ps.isKnockedback && rb.velocity.y > 0 && ps.wasOnGround && heldJump)
        {
            rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1.5f;
        }    
    }
    //private void ApplyHigh()
    //{
    //    rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        
    //}
    //private void ApplyLow()
    //{
    //    rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    //}
}