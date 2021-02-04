using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : ScriptableObject
{
    public string entityName;
    public int maxHealth;
    public float moveSpeed;
}
