using Orakeshi.ApocalypseZ.App;
using Orakeshi.ApocalypseZ.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private int maxHealth = 100;
    private int currentHealth = 100;

    private List<Weapon> weapons = new List<Weapon>();
    
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    public int MaxHealth
    {
        set
        {
            maxHealth = value;
        }
    }

    public Weapon EquippedWeapon
    {
        get
        {
            return weapons[0];
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        if(currentHealth <= 0)
        {
            
            print("DEAD");
        }
    }

    public void DropEquippedWeapon()
    {
        weapons.Remove(weapons[0]);
    }
}
