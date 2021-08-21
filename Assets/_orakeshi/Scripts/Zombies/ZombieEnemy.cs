using Orakeshi.ApocalypseZ.App;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public class ZombieEnemy : MonoBehaviour, IDamageable
    {
        int maxHealth = 100;
        int currentHealth = 100;
        int damageOutput = 5;

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
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;
            if (currentHealth <= 0)
            {
                Animator deathAnim = GetComponent<Animator>();
                deathAnim.SetTrigger("Dead");
                GetComponent<AudioSource>().enabled = false;
                GetComponent<ZombieNavMesh>().enabled = false;
                //Disable zombie navmesh

                print("Dead");
                // Play death animation
            }
            else
            {   
                // play hit animation
            }
        }

        void Attack()
        {
            // Play attack animation
        }


        public bool damaged = false;
        public int damageTaken;

        //void ZombieDead()
        //{
        //    print("DEAD");
        //    Destroy(gameObject);
        //    zombieManager.totalDead += 1;
        //}

        private void Update()
        {
            //if (damaged)
            //{
            //    ZombieDamaged();
            //    damaged = false;
            //}

            //if(health <= 0)
            //{
            //    ZombieDead();
            //}
        }

    }
}

