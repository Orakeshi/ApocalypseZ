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
            if((deathTracker.TotalZombieDeaths % 20) == 0 && deathTracker.TotalZombieDeaths != 0)
            {
                zombieManager.StartCoroutine(zombieManager.ZombieSpawn("Boss"));
                print("Doing");
            }

            else
            {
                // If zombie dies -> Need to keep track in the wave script

                print("Doing");
                zombieManager.StartCoroutine(zombieManager.ZombieSpawn("Zombie"));
                StartCoroutine(ZombieSpawnWrapper());
            }
            
        }

        private void Update()
        {
            //print(deathTracker.TotalZombieDeaths);
        }
    }
}

