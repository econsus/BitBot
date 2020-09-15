using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Scriptable Object")]
    public Player player;

    [Space]

    [Header("Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float wallSlideSpeed;
    private float x, y, xRaw, yRaw;
    private Vector2 inputDir;

    [HideInInspector]
    public bool canMove = true;

    [Space]

    [Header("Booleans")]
    public bool facingLeft = true;
    public bool isWallSliding = false;
    private bool jumpRequest = false;

    private Rigidbody2D rb;
    private PlayerCollision coll;
    private AnimationScript anim;
    private SpriteRenderer sr;

    private EventManager em;
    public bool isKnockedback = false;

    private void Awake()
    {
        speed = player.moveSpeed;
        jumpForce = player.jumpForce;
        wallSlideSpeed = player.wallSlideSpeed;
        em = FindObjectOfType<EventManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PlayerCollision>();
        anim = GetComponentInChildren<AnimationScript>();
        sr = GetComponentInChildren<SpriteRenderer>();
        
    }
    private void OnEnable()
    {
        em.OnKnockedBackEvent += ApplyKnockback;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw = Input.GetAxisRaw("Vertical");
        anim.SetHorizontal(x);

        inputDir = new Vector2(x, y);

        if (Input.GetButtonDown("Jump"))
        {
            jumpRequest = true;
        }
    }
    private void FixedUpdate()
    {
        Run(inputDir);
        Flip(inputDir);
        WallSlide(xRaw);
        LimitJump();

        if (jumpRequest)
        {
            Jump(Vector2.up);
            jumpRequest = false;
        }
    }

    private void LimitJump()
    {
        if(rb.velocity.y > jumpForce && Input.GetButton("Jump"))
        {
            //rb.velocity = new Vector2(rb.velocity.x, Physics2D.gravity.y);
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(rb.velocity.x, jumpForce), 10f * Time.deltaTime);
        }
    }

    private void Run(Vector2 dir)
    {
        if(!canMove)
        {
            return;
        }
        if(!isKnockedback)
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(dir.x * speed, rb.velocity.y), 5f * Time.deltaTime);
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
            if(coll.bottomOffset.x < 0)
            {
                coll.FlipBottomOffsetX();
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
            if (coll.bottomOffset.x > 0)
            {
                coll.FlipBottomOffsetX();
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

        anim.TriggerAnim("Jump");

        rb.velocity = Vector2.zero;
        rb.velocity += dir * jumpForce;
    }

    private void WallSlide(float xRaw)
    {
        if(!canMove)
        {
            return;
        }
        if(!coll.onWall)
        {
            return;
        }
        if (coll.onLeftWall && xRaw < 0 || coll.onRightWall && xRaw > 0)
        {
            SlideDown();
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void SlideDown()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity = Vector2.down * wallSlideSpeed;
            isWallSliding = true;
        }
    }

    public void Halt()
    {
        rb.velocity = Vector2.zero;
        anim.SetHorizontal(0);
    }
    private void ApplyKnockback(Vector3 dir, float multiplier)
    {
        if(coll.onGround)
        {
            //return;
        }
        StartCoroutine(KnockbackCycle(dir, multiplier));
    }

    private IEnumerator KnockbackCycle(Vector3 dir, float multiplier)
    {
        isKnockedback = true;
        rb.velocity += new Vector2(dir.x * multiplier, dir.y * multiplier);
        yield return new WaitForSeconds(0.4f);
        isKnockedback = false;
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
