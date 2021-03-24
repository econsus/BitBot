using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Scriptable Objects/Entity/Player")]
public class Player : Entity
{
    public float jumpForce;
    public float dashSpeed;
    public float dashCooldown;
    public float wallSlideSpeed;
    //Etc
}
