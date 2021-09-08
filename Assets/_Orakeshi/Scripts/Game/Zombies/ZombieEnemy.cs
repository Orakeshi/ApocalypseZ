using System.Collections;
using System.Collections.Generic;
using Orakeshi.ApocalypseZ.Game.Zombies;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Game.Zombies
{
    public class ZombieEnemy : MonoBehaviour, IDamageable
    {
        private DeathTracker deathTracker;
        private Animator animator;
        private int maxHealth = 100;
        public int currentHealth = 100;

        public int id;
        private static readonly int Dead = Animator.StringToHash("Dead");

        private void Start()
        {
            deathTracker = GameObject.Find("ZombieManager").GetComponent<DeathTracker>();
            animator = GetComponent<Animator>();

            GameEvents.current.ONZombieTriggerDeath += OnZombieDeath;
        }

        public int CurrentHealth => currentHealth;

        public int MaxHealth
        {
            set => maxHealth = value;
        }

        public int DamageOutput { get; set; } = 5;

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                GameEvents.current.ZombieTriggerDeath(id);
                // Play death animation here
            }
            else
            {
                print("Doing nothing rn");
                // play hit animation
            }
        }

        private void Attack()
        {
            // When the zombie is in range of the player, play the attack animation

            //deathAnim.SetTrigger("Attack");
            // Play attack animation
        }

        private void OnZombieDeath(int zombieID)
        {
            if (zombieID != this.id) return;
            deathTracker.TotalZombieDeaths++;
            animator.SetTrigger(Dead);
            
            GetComponent<AudioSource>().enabled = false;
            GetComponent<ZombieNavMesh>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            //Disable zombie navmesh
        }

        private void OnDestroy()
        {
            GameEvents.current.ONZombieTriggerDeath -= OnZombieDeath;
        }
    }
}

