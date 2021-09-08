using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Orakeshi.ApocalypseZ.Game.Zombies
{
    public class ZombieManager : MonoBehaviour
    {
        public Transform[] zombieSpawnPoints;
        public GameObject[] zombiePrefab;
        public GameObject bossZombie;

        public PathCreator[] routes;

        public Transform player;

        public IEnumerator ZombieSpawn(int zombieID)
        {
            int randomSpawn = Random.Range(0, zombieSpawnPoints.Length);

            int randomZombie = Random.Range(0, zombiePrefab.Length);

            GameObject currentZombie = Instantiate(zombiePrefab[randomZombie], zombieSpawnPoints[randomSpawn].transform.position, Quaternion.identity);

            currentZombie.GetComponent<ZombieNavMesh>().movePositionTransform = player;
            currentZombie.GetComponent<ZombieEnemy>().id = zombieID;

            yield return null;
        }

        public IEnumerator BossZombieSpawn(int zombieID)
        {
            int randomSpawn = Random.Range(0, zombieSpawnPoints.Length);

            GameObject currentBossZombie = Instantiate(bossZombie, zombieSpawnPoints[randomSpawn].transform.position, Quaternion.identity);

            currentBossZombie.GetComponent<ZombieNavMesh>().movePositionTransform = player;
            currentBossZombie.GetComponent<ZombieEnemy>().id = zombieID;

            yield return null;

        }
    }
}

