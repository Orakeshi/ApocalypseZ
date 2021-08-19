using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public class WaveManager : MonoBehaviour
    {
        int totalDeadZombies = 0;
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
            if(totalDeadZombies % 20 == 0)
            {
                zombieManager.ZombieSpawn("Boss");
            }
            else
            {
                zombieManager.ZombieSpawn("Zombie");
                StartCoroutine(ZombieSpawnWrapper());
            }
            
        }
    }
}

