using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Player player;
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
