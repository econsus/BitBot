using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Entity/Enemy")]
public class Enemy : Entity
{
    public AIType enemyType;
}

public enum AIType
{
    FlyingDrone,
    GroundGunner
}
