using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [Header("States")]
    public bool walking;
    public bool facingLeft;
    public bool jumping;
    public bool onGround;
    public bool onLeftWall;
    public bool onRightWall;
    public bool onWall;
    public bool dashing;
    public bool isKnockedback;
    public bool wasOnGround = false;
    public bool recoilingX;
    public bool recoilingY;
}
