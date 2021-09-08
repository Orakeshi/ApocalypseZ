using System.Collections;
using System.Collections.Generic;
using Orakeshi.ApocalypseZ.Game.Zombies;
using Orakeshi.ApocalypseZ.Game.Weapon;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Game.Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        private int maxHealth = 100;
        private int currentHealth = 100;

        [SerializeField] private List<WeaponTemplate> weapons = new List<WeaponTemplate>();
    
        public int CurrentHealth => currentHealth;

        public int MaxHealth
        {
            set => maxHealth = value;
        }

        public WeaponTemplate EquippedWeapon => weapons[0];

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

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
}
