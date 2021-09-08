using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Orakeshi.ApocalypseZ.XR
{
    [RequireComponent(typeof(Transform))]
    public class LineRenderer : MonoBehaviour
    {
        private UnityEngine.LineRenderer line;
        Transform target;
        NavMeshAgent agent;

        private void Start()
        {
            line = GetComponent<UnityEngine.LineRenderer>();
            agent = GetComponent<NavMeshAgent>();
            GetPath();
        }

        void GetPath()
        {
            line.SetPosition(0, transform.position);
        }
    }
}

