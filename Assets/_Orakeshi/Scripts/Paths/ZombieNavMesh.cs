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
            if (movePositionTransform != null)
            {
                navMeshAgent.destination = movePositionTransform.position;
            }
            else
            {
                navMeshAgent.destination = gameObject.transform.position;
            }

            if (!navMeshAgent.pathPending)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                    {
                        ZombieEnemy zombie = gameObject.GetComponent<ZombieEnemy>();
                        Animator anim = zombie.GetComponent<Animator>();
                        anim.SetTrigger("Attack");
                    }
                }
            }
            
            
        }
    }
}

