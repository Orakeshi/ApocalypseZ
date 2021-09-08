using System.Collections;
using System.Collections.Generic;
using Orakeshi.ApocalypseZ.Game.Zombies;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Game.Zombies
{
    public class WaveManager : MonoBehaviour
    {
        private float timeToSpawn = 10;
        [SerializeField] public ZombieManager zombieManager;
        [SerializeField] public DeathTracker deathTracker;

        private bool bossAlive = false;

        private bool bossRound = false;

        public int id = 0;
        private void Start()
        {
            GameEvents.current.ONZombieTriggerSpawn += OnZombieSpawn;
            StartCoroutine(ZombieSpawnWrapper());
        }

        private IEnumerator ZombieSpawnWrapper()
        {
            yield return new WaitForSeconds(timeToSpawn);
            NextWave();
        }

        private void OnZombieSpawn(int zombieID)
        {
            zombieManager.StartCoroutine(zombieManager.ZombieSpawn(zombieID));
            StartCoroutine(ZombieSpawnWrapper());
        }

        private void NextWave()
        {
            if ((deathTracker.TotalZombieDeaths % 20) == 0 && deathTracker.TotalZombieDeaths != 0 && bossRound == false)
            {
                StartCoroutine(BossRound());
            }

            else
            {
                // If zombie dies -> Need to keep track in the wave script
                print("Doing");
                id++;
                GameEvents.current.ZombieTriggerSpawn(id);
                
            }
            
        } // Stop tracking zombies ->

        private IEnumerator BossRound() // Start boss round
        {
            bossRound = true;
            zombieManager.StartCoroutine(zombieManager.BossZombieSpawn(id));
            print("Doing");
            
            for (int i = 0; i < 30; i++)
            {
                //zombieManager.StartCoroutine(zombieManager.ZombieSpawn("Zombie"));
                id++;
                GameEvents.current.ZombieTriggerSpawn(id);
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
        }
        // If boss round - dont track zombie kills (otherwise it will trigger another boss round)
        // Once boss dead restart normal spawn & Buff zombies -> Give Zombie manager reference to zombie script to increase health.
    }
}

