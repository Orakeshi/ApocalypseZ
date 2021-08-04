using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    float distanceTravelled;

    Vector3 lastPos;

    void Start()
    {
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
        lastPos = transform.position;
    }

    void Update()
    {
        var currentPosition = transform.position;

        if (pathCreator != null)
        {
            speed = (currentPosition - lastPos).magnitude / Time.deltaTime;
            print(currentPosition);
            print(lastPos);
            print(currentPosition - lastPos);
            print(speed);
            distanceTravelled += speed * Time.deltaTime;

            //transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
        lastPos = currentPosition;
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}












