using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerMovement move;
    private PlayerCollision coll;
    private Transform camTarget;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        move = GetComponentInParent<PlayerMovement>();
        coll = GetComponentInParent<PlayerCollision>();
        camTarget = GameObject.Find("Cam Target").transform;
    }

    void Update()
    {
        groundCheck(coll.onGround);
        setYVelocity(rb.velocity.y);
        setLookingUp();
    }

    private void setYVelocity(float y)
    {
        anim.SetFloat("Y Velocity", y);
    }
    private void groundCheck(bool onGround)
    {
        anim.SetBool("onGround", onGround);
    }
    public void setHorizontal(float x)
    {
        anim.SetFloat("Horizontal", x);
    }
    public void triggerJump()
    {
        anim.SetTrigger("Jump");
    }
    public void setSpeed(string name, float speed)
    {
        anim.SetFloat(name, speed);
    }
    private void setLookingUp()
    {
        bool temp;
        if (camTarget.position.y > -2.1f)
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
