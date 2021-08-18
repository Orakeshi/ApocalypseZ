using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public class ZombieNavMesh : MonoBehaviour
    {
        [SerializeField] public Transform movePositionTransform;

        private NavMeshAgent navMeshAgent;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            navMeshAgent.destination = movePositionTransform.position;
        }
    }
}

