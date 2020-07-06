using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipPathing : MonoBehaviour
{
    [SerializeField]
    private List<Transform> waypoints;
    [SerializeField]
    private float speed = 10f;

    private int waypointIndex = 0;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        MoveTo();
    }

    private void MoveTo()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;

            transform.position = waypoints[waypointIndex].transform.position;
        }
    }
}
