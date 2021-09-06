using Orakeshi.ApocalypseZ.App;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public class ZombieEnemy : MonoBehaviour, IDamageable
    {
        private DeathTracker deathTracker;
        Animator deathAnim;
        int maxHealth = 100;
        int currentHealth = 100;
        int damageOutput = 5;

        void Start()
        {
            deathTracker = GameObject.Find("ZombieManager").GetComponent<DeathTracker>();
            deathAnim = GetComponent<Animator>();

            GameEvents.current.onZombieTriggerDeath += OnZombieDeath;
        }

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

        public int DamageOutput
        {
            get
            {
                return damageOutput;
            }
            set
            {
                damageOutput = value;
            }
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            if (currentHealth <= 0)
            {
                GameEvents.current.ZombieTriggerDeath();
                // Play death animation
            }
            else
            {   
                // play hit animation
            }
        }

        void Attack()
        {
            Animator deathAnim = GetComponent<Animator>();

            // When the zombie is in range of the player, play the attack animation

            //deathAnim.SetTrigger("Attack");
            // Play attack animation
        }

        void OnZombieDeath()
        {
            deathTracker.TotalZombieDeaths++;

            deathAnim.SetTrigger("Dead");
            GetComponent<AudioSource>().enabled = false;
            GetComponent<ZombieNavMesh>().enabled = false;
            //Disable zombie navmesh

            print("Dead");
            print("DEAD");
        }

        private void OnDestroy()
        {
            GameEvents.current.onZombieTriggerDeath -= OnZombieDeath;
        }
    }
}

