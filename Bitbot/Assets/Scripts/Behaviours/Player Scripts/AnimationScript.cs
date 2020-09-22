using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerMovement move;
    private PlayerStates ps;
    private Transform camTarget;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        move = GetComponentInParent<PlayerMovement>();
        ps = GetComponentInParent<PlayerStates>();
        camTarget = GameObject.Find("Cam Target").transform;
    }

    void Update()
    {
        GroundCheck(ps.onGround);
        SetYVelocity(rb.velocity.y);
        SetLookingUp();
    }

    private void SetYVelocity(float y)
    {
        anim.SetFloat("Y Velocity", y);
    }
    private void GroundCheck(bool onGround)
    {
        anim.SetBool("onGround", onGround);
    }
    public void SetHorizontal(float x)
    {
        anim.SetFloat("Horizontal", x);
    }
    public void TriggerAnim(string str)
    {
        anim.SetTrigger(str);
    }
    public void SetSpeed(string name, float speed)
    {
        anim.SetFloat(name, speed);
    }
    private void SetLookingUp()
    {
        bool temp;
        if (camTarget.position.y > transform.position.y + 2.1f)
        {
            temp = true;
        }
        else
        {
            temp = false;
        }
        anim.SetBool("isLookingUp", temp);
    }
}
