using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public class ZombieManager : MonoBehaviour
    {
        public Transform[] ZombieSpawnPoints;
        public GameObject[] ZombiePrefab;
        public GameObject[] BossZombie;

        public PathCreator[] routes;

        public Transform Player;

        public int zombieHealth = 70;
        public int zombieDamage = 5;
        public int totalDead = 0;

        public IEnumerator ZombieSpawn(string zombieType)
        {
            if(zombieType == "Zombie")
            {
                int randomSpawn = Random.Range(0, ZombieSpawnPoints.Length);

                int randomZombie = Random.Range(0, ZombiePrefab.Length);

                GameObject currentZombie = Instantiate(ZombiePrefab[randomZombie], ZombieSpawnPoints[randomSpawn].transform.position, Quaternion.identity);

                currentZombie.GetComponent<ZombieNavMesh>().movePositionTransform = Player;

                yield return null;
            }

            else
            {
                // Spawn big zombie
            }

        }



    }
}

