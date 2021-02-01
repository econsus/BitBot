using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Scriptable Object")]
    public Player player;

    [Space(2)]

    [Header("Constants")]
    private const float DoubleInputTime = 0.2f;

    [Space(2)]

    [Header("Stats")]
    [SerializeField] private float speed; //Multiplier x velocity saat lari
    [SerializeField] private float jumpForce; //Multiplier y velocity saat lompat
    [SerializeField] private float dashSpeed = 100f; //Multiplier x velocity saat dashing
    [SerializeField] private float dashCooldown; //Cooldown dash
    [SerializeField] private float wallSlideSpeed; //Velocity y saat wall sliding
    [SerializeField] private float coyoteTime = 0.15f; //Toleransi waktu input setelah meninggalkan ground
    private Vector2 dashDirection = new Vector2();
    private float coyoteTimeCounter; //Counter waktu input sejak meninggalkan ground
    private float x, y, xRaw; //Axes
    private Vector2 inputDir; //Vektor berisi input axes

    [Space(2)]

    [Header("Booleans")]
    public bool canMove = true; //Izin untuk bergerak
    private bool canDash = true; //Izin untuk ngedash
    private bool wantToDash = false; //Permintaan ngedash
    public bool isWallSliding = false; //Keadaan wall sliding

    [Space(2)]

    [Header("Objects")]
    public GameObject dustParticle;
    public Transform dustTransform;

    private Rigidbody2D rb;
    private PlayerStates ps;
    private AnimationScript anim;
    private SpriteRenderer sr;
    private AudioManager am;
    private EventManager em;

    private void Awake()
    {
        speed = player.moveSpeed;
        jumpForce = player.jumpForce;
        wallSlideSpeed = player.wallSlideSpeed;
        am = FindObjectOfType<AudioManager>();
        em = FindObjectOfType<EventManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<PlayerStates>();
        anim = GetComponentInChildren<AnimationScript>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }
    private void OnEnable()
    {
        em.OnKnockedBackEvent += ApplyKnockback;
        em.OnDoubleTapEvent += DashInput;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        xRaw = Input.GetAxisRaw("Horizontal");
        //yRaw = Input.GetAxisRaw("Vertical");
        anim.SetHorizontal(x);

        inputDir = new Vector2(x, y);

        if (Input.GetButtonDown("Jump"))
        {
            ps.jumping = true;
        }
    }
    private void FixedUpdate()
    {
        GroundCheck();
        Run(inputDir);
        WallSlide(xRaw);
        Flip(inputDir);
        if(ps.jumping)
        {
            Jump();
            ps.jumping = false;
        }
        if(wantToDash)
        {
            Dash(dashDirection);
            wantToDash = false;
        }
    }
    private void GroundCheck()
    {
        if(ps.onGround)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    private void Run(Vector2 dir)
    {
        if(!canMove)
        {
            return;
        }
        if(ps.dashing)
        {
            return;
        }
        if(!ps.isKnockedback)
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(dir.x * speed, rb.velocity.y), 4f * Time.deltaTime);
        }
    }

    private void Flip(Vector2 dir)
    {
        if(isWallSliding)
        {
            return;
        }
        if (!ps.facingLeft)
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
        else
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
    private void Jump()
    {
        if(!canMove)
        {
            return;
        }

        if(coyoteTimeCounter > 0)
        {
            anim.TriggerAnim("Jump");
            GameObject temp = Instantiate(dustParticle, dustTransform);
            temp.transform.parent = null;

            am.PlaySound("Jump");

            if(!ps.isKnockedback)
            {
                rb.gravityScale = 1.5f;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.velocity += Vector2.up * jumpForce;
            }
        }
    }

    private void WallSlide(float xRaw)
    {
        if(!canMove)
        {
            return;
        }
        if (ps.onLeftWall && xRaw < 0 || ps.onRightWall && xRaw > 0)
        {
            if (rb.velocity.y < 0 || rb.velocity.y < -wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
                isWallSliding = true;
            }
            else
            {
                isWallSliding = false;
            }
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void DashInput(KeyCode kcode)
    {
        if(!canDash)
        {
            return;
        }
        if (kcode == KeyCode.D)
        {
            dashDirection = Vector2.right;
            wantToDash = true;
        }
        else if (kcode == KeyCode.A)
        {
            dashDirection = Vector2.left;
            wantToDash = true;
        }
    }

    private void Dash(Vector2 dir)
    {
        am.PlaySound("Dash");
        em.OnShakeCameraEventMethod(10, 0.2f);
        StartCoroutine(DashWait(dir));
    }

    private IEnumerator DashWait(Vector2 dir)
    {
        ps.dashing = true;
        canDash = false;

        rb.velocity = Vector2.zero;
        rb.velocity = dir.normalized * dashSpeed;

        rb.gravityScale = 0.5f;
        GetComponent<JumpModifier>().enabled = false;

        if (ps.isKnockedback)
        {
            GetComponent<JumpModifier>().enabled = true;
            ps.dashing = false;
        }
        else
        {
            yield return new WaitForSeconds(0.05f);
            GetComponent<JumpModifier>().enabled = true;
            ps.dashing = false;
        }
        StartCoroutine(DashRecovery());
    }
    private IEnumerator DashRecovery()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    public void Halt()
    {
        rb.velocity = Vector2.zero;
        anim.SetHorizontal(0);
    }
    private void ApplyKnockback(Vector2 dir, float multiplier)
    {
        if(ps.dashing)
        {
            return;
        }
        if (ps.onGround)
        {
            ps.wasOnGround = true;
        }
        else
        {
            ps.wasOnGround = false;
        }
        StartCoroutine(KnockbackCycle(dir, multiplier));
    }

    private IEnumerator KnockbackCycle(Vector2 dir, float multiplier)
    {
        ps.isKnockedback = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        //rb.velocity += dir.normalized * multiplier;
        rb.AddForce(dir * multiplier, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        ps.isKnockedback = false;
    }

    public void Knockback(float x, float y)
    {
        Vector2 dir;

        if(!ps.facingLeft)
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
