﻿using PathCreation;
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

        void Start()
        {
            StartCoroutine(ZombieSpawn());
            //SpawnNewZombie();
        }

        void SpawnNewZombie()
        {
            int random;
            random = Random.Range(0, 1);
            //Instantiate(ZombiePrefab, ZombieSpawnPoints[random].transform.position, Quaternion.identity);
        }

        IEnumerator ZombieSpawn()
        {
            int random;
            random = Random.Range(0, 2);

            int randomZombie = Random.Range(0, ZombiePrefab.Length);

            GameObject currentZombie = Instantiate(ZombiePrefab[randomZombie], ZombieSpawnPoints[random].transform.position, Quaternion.identity);

            if (random == 0)
            {
                currentZombie.GetComponent<PathFollower>().pathCreator = routes[0];
                //ZombiePrefab.GetComponent<PathFollower>().pathCreator = routes[0];
            }
            else
            {
                currentZombie.GetComponent<PathFollower>().pathCreator = routes[1];
                //ZombiePrefab.GetComponent<PathFollower>().pathCreator = routes[1];
            }

            yield return new WaitForSeconds(10f);
            StartCoroutine(ZombieSpawn());
        }


    }
}
