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

        public PathCreator[] routes;

        public Transform Player;

        void Start()
        {
            StartCoroutine(ZombieSpawn());
            //SpawnNewZombie();
        }

        void SpawnNewZombie()
        {
            int random;
            random = Random.Range(0, 10);
            //Instantiate(ZombiePrefab, ZombieSpawnPoints[random].transform.position, Quaternion.identity);
        }

        IEnumerator ZombieSpawn()
        {

            int randomSpawn = Random.Range(0, ZombieSpawnPoints.Length);

            int randomZombie = Random.Range(0, ZombiePrefab.Length);

            

            GameObject currentZombie = Instantiate(ZombiePrefab[randomZombie], ZombieSpawnPoints[randomSpawn].transform.position, Quaternion.identity);

            currentZombie.GetComponent<ZombieNavMesh>().movePositionTransform = Player;

            

            yield return new WaitForSeconds(10f);
            StartCoroutine(ZombieSpawn());
        }



    }
}

