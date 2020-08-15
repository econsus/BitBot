using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerMovement move;
    private PlayerCollision coll;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        move = GetComponentInParent<PlayerMovement>();
        coll = GetComponentInParent<PlayerCollision>();
    }

    void Update()
    {
        groundCheck(coll.onGround);
        setYVelocity(rb.velocity.y);
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
}
