using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 10f;
    public float jumpForce = 7f;

    [Space]

    [Header("Booleans")]
    public bool facingRight = true;

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
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        anim.setHorizontal(x);

        Vector2 dir = new Vector2(x, y);
        run(dir);

        flip(dir);

        if (Input.GetButtonDown("Jump") && coll.onGround)
        {
            jump(Vector2.up);
        }
    }

    private void run(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    private void flip(Vector2 dir)
    {
        if (!facingRight)
        {
            if(dir.x < 0)
            {
                anim.setSpeed("playbackSpeed", -1f);
            }
            else
            {
                anim.setSpeed("playbackSpeed", 1f);
            }
            sr.flipX = false;
        }
        if (facingRight)
        {
            if (dir.x > 0)
            {
                anim.setSpeed("playbackSpeed", -1f);
            }
            else
            {
                anim.setSpeed("playbackSpeed", 1f);
            }
            sr.flipX = true;
        }
    }
    private void jump(Vector2 dir)
    {
        if(!coll.onGround)
        {
            return;
        }

        anim.triggerJump();

        rb.velocity = Vector2.zero;
        rb.velocity += dir * jumpForce;
    }
}
