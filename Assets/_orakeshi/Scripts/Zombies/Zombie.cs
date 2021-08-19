using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public class Zombie : MonoBehaviour
    {
        [SerializeField] public ZombieManager zombieManager;
        int health;
        int damage;

        private void Awake()
        {
            health = zombieManager.zombieHealth;
            damage = zombieManager.zombieDamage;
        }

        IEnumerator

    }

