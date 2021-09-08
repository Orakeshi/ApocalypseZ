using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Orakeshi.ApocalypseZ.Game.Zombies
{
    public class ZombieNavMesh : MonoBehaviour
    {
        [SerializeField] public Transform movePositionTransform;

        private NavMeshAgent navMeshAgent;
        private static readonly int Attack = Animator.StringToHash("Attack");
        private Animator anim;
        private ZombieEnemy zombie;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();

            zombie = gameObject.GetComponent<ZombieEnemy>();
            
            anim = zombie.GetComponent<Animator>();
        }

        private void Update()
        {
            navMeshAgent.destination = movePositionTransform != null ? movePositionTransform.position : gameObject.transform.position;

            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f))
            {
                
                anim.SetTrigger(Attack);
            }
        }
    }
}

