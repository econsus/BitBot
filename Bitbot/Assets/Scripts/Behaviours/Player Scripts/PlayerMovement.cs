using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 10f;
    public float jumpForce = 7f;

    public bool canMove = true;

    [Space]

    [Header("Booleans")]
    public bool facingLeft = true;
    private bool jumpRequest = false;

    private Rigidbody2D rb;
    private PlayerCollision coll;
    private AnimationScript anim;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PlayerCollision>();
        anim = GetComponentInChildren<AnimationScript>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        anim.SetHorizontal(x);

        Vector2 dir = new Vector2(x, y);
        Run(dir);

        Flip(dir);

        if (Input.GetButtonDown("Jump") && coll.onGround)
        {
            jumpRequest = true;
        }
    }
    private void FixedUpdate()
    {
        if(jumpRequest)
        {
            Jump(Vector2.up);
            jumpRequest = false;
        }
    }
    private void Run(Vector2 dir)
    {
        if(!canMove)
        {
            return;
        }
        else
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
    }

    private void Flip(Vector2 dir)
    {
        if (!facingLeft)
        {
            if(dir.x < 0)
            {
                anim.SetSpeed("playbackSpeed", -1f);
            }
            else
            {
                anim.SetSpeed("playbackSpeed", 1f);
            }
            sr.flipX = false;
        }
        if (facingLeft)
        {
            if (dir.x > 0)
            {
                anim.SetSpeed("playbackSpeed", -1f);
            }
            else
            {
                anim.SetSpeed("playbackSpeed", 1f);
            }
            sr.flipX = true;
        }
    }
    private void Jump(Vector2 dir)
    {
        if(!coll.onGround)
        {
            return;
        }
        if(!canMove)
        {
            return;
        }
        else
        {
            anim.TriggerAnim("Jump");

            rb.velocity = Vector2.zero;
            rb.velocity += dir * jumpForce;
        }
    }

    public void Halt()
    {
        rb.velocity = Vector2.zero;
        anim.SetHorizontal(0);
    }

    public void Knockback(float x, float y)
    {
        Vector2 dir;

        if(!facingLeft)
        {
            dir = Vector2.left * x + Vector2.up * y;
        }
        else
        {
            dir = Vector2.right * x + Vector2.up * y;
        }
        rb.velocity = Vector2.zero;
        rb.AddForce(dir, ForceMode2D.Impulse);
    }
}
