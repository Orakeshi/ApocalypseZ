using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Orakeshi.ApocalypseZ.Game.Weapon
{
    public class OnTargetReached : MonoBehaviour
    {
        public float threshold = 0.02f;
        public Transform target;
        public UnityEvent onReached;
        private bool wasReached = false;
        private void FixedUpdate()
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < threshold && !wasReached)
            {
                onReached.Invoke();
                wasReached = true;
            }
            else if (distance >= threshold)
            {
                wasReached = false;
            }
        }
    }
}

