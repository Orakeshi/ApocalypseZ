using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public class WaveManager : MonoBehaviour
    {
        float timeToSpawn = 10;
        [SerializeField] public ZombieManager zombieManager;

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
            if((zombieManager.totalDead % 20) == 0 && zombieManager.totalDead != 0)
            {
                zombieManager.StartCoroutine(zombieManager.ZombieSpawn("Boss"));
                print("Doing");
            }
            else
            {
                print("Doing");
                zombieManager.StartCoroutine(zombieManager.ZombieSpawn("Zombie"));
                StartCoroutine(ZombieSpawnWrapper());
            }
            
        }
    }
}

