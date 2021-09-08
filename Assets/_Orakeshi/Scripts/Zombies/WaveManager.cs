using Orakeshi.ApocalypseZ.App;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public class WaveManager : MonoBehaviour
    {
        float timeToSpawn = 10;
        [SerializeField] public ZombieManager zombieManager;
        [SerializeField] public DeathTracker deathTracker;

        bool bossAlive = false;

        bool bossRound = false;
        private void Start()
        {
            
            StartCoroutine(ZombieSpawnWrapper());
        }

        IEnumerator ZombieSpawnWrapper()
        {
            yield return new WaitForSeconds(timeToSpawn);
            NextWave();
        }

        void NextWave()
        {
            if ((deathTracker.TotalZombieDeaths % 20) == 0 && deathTracker.TotalZombieDeaths != 0 && bossRound == false)
            {
                StartCoroutine(BossRound());
            }

            else
            {
                // If zombie dies -> Need to keep track in the wave script

                print("Doing");
                zombieManager.StartCoroutine(zombieManager.ZombieSpawn("Zombie"));
                StartCoroutine(ZombieSpawnWrapper());
            }
            
        } // Stop tracking zombies ->

        IEnumerator BossRound() // Start boss round
        {
            bossRound = true;
            zombieManager.StartCoroutine(zombieManager.ZombieSpawn("Boss"));
            print("Doing");
            
            for (int i = 0; i < 30; i++)
            {
                zombieManager.StartCoroutine(zombieManager.ZombieSpawn("Zombie"));
                yield return new WaitForSeconds(0.2f); // Spawning zombies on the boss round
            }
        }

        private void Update()
        {
            if (!bossAlive)
            {
                if (GameObject.FindGameObjectWithTag("Boss"))
                {
                    bossAlive = true;
                }
                else
                {
                    return;
                }
            }

            //print(deathTracker.TotalZombieDeaths);
        }
        // If boss round - dont track zombie kills (otherwise it will trigger another boss round)
        // Once boss dead restart normal spawn & Buff zombies -> Give Zombie manager reference to zombie script to increase health.
    }
}

