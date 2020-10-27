using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCollider : MonoBehaviour
{
    private PlayerStates ps;
    private BoxCollider2D bc;
    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerStates>();
        bc = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        flipColliderX();
    }

    void flipColliderX()
    {
        //if(ps.isWallSliding)
        //{
        //    return;
        //}
        if(!ps.facingLeft)
        {
            if (bc.offset.x < 0)
            {
                bc.offset = new Vector2(-bc.offset.x, bc.offset.y);
            }
        }
        if(ps.facingLeft)
        {
            if (bc.offset.x > 0)
            {
                bc.offset = new Vector2(-bc.offset.x, bc.offset.y);
            }
        }
    }
}
