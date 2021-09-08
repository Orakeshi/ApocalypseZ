using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Game.Paths
{
    public class PathFollow : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        private float distanceTravelled;

        private Vector3 lastPosition;
        private void Start()
        {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
            lastPosition = transform.position;
        }

        private void Update()
        {
            var currentPosition = transform.position;

            
            if (pathCreator != null)
            {
                // Magnitude causing speeds to be > 1000
                speed = (currentPosition - lastPosition).magnitude / Time.deltaTime;

                distanceTravelled += speed * Time.deltaTime;

                //transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
            lastPosition = currentPosition;
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}













