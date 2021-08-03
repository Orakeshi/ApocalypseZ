using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public Transform[] ZombieSpawnPoints;
    public GameObject ZombiePrefab;

    void Start()
    {
        SpawnNewZombie();
    }

    void SpawnNewZombie()
    {
        Instantiate(ZombiePrefab, ZombieSpawnPoints[0].transform.position, Quaternion.identity);
    }
}
