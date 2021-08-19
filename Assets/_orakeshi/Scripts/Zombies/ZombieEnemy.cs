using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public class ZombieEnemy : MonoBehaviour
    {
        ZombieManager zombieManager;
        int health;
        int attackDamage;
        public bool damaged = false;
        public int damageTaken;
        private void Awake()
        {
            zombieManager = GameObject.Find("ZombieManager").GetComponent<ZombieManager>();
        }

        private void Start()
        {
            health = zombieManager.zombieHealth;
            attackDamage = zombieManager.zombieDamage;
        }

        void ZombieDamaged()
        {
            health -= damageTaken;
        }

        void ZombieDead()
        {
            print("DEAD");
            Destroy(gameObject);
            zombieManager.totalDead += 1;
        }

        private void Update()
        {
            if (damaged)
            {
                ZombieDamaged();
                damaged = false;
            }

            if(health <= 0)
            {
                ZombieDead();
            }
        }

    }
}

