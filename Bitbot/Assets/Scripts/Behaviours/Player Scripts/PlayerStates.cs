using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public Player player;

    [Header("States")]
    public bool walking;
    public bool facingLeft;
    public bool jumping;
    public bool onGround;
    public bool onLeftWall;
    public bool onRightWall;
    public bool onWall;
    public bool isKnockedback;
    public bool wasOnGround = false;
    public bool recoilingX;
    public bool recoilingY;

    [SerializeField] private int currentHealth;
    void Awake()
    {
        currentHealth = player.maxHealth;
    }

    public void DecreaseCurrentHealth(int point)
    {
        currentHealth -= point;
    }
}
