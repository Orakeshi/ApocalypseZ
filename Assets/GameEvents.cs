using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onZombieTriggerSpawn;

    public void ZombieTriggerSpawn()
    {
        if (onZombieTriggerSpawn != null)
        {
            onZombieTriggerSpawn();
        }
    }

    public event Action onZombieTriggerDeath;
    public void ZombieTriggerDeath()
    {
        if (onZombieTriggerDeath != null)
        {
            onZombieTriggerDeath();
        }
    }
}
