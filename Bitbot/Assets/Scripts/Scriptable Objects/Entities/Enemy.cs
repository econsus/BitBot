using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable Objects/Entity/Enemy")]
public class Enemy : Entity
{
    public AIType enemyType;
}

public enum AIType
{
    FlyingDrone,
    GroundGunner
}
