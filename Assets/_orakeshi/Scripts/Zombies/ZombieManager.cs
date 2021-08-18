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
            int random;
            random = Random.Range(0, 9);

            int randomZombie = Random.Range(0, ZombiePrefab.Length);

            GameObject currentZombie = Instantiate(ZombiePrefab[randomZombie], ZombieSpawnPoints[random].transform.position, Quaternion.identity);

            //if (random == 0)
            //{
            //    currentZombie.GetComponent<PlayerNavMesh>().movePositionTransform = Player;
            //    //ZombiePrefab.GetComponent<PathFollower>().pathCreator = routes[0];
            //}
            //else
            //{
            //    currentZombie.GetComponent<PlayerNavMesh>().movePositionTransform = Player;
            //    //ZombiePrefab.GetComponent<PathFollower>().pathCreator = routes[1];
            //}

            currentZombie.GetComponent<ZombieNavMesh>().movePositionTransform = Player;

            yield return new WaitForSeconds(10f);
            StartCoroutine(ZombieSpawn());
        }


    }
}

