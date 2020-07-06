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
    private bool isMovingRight = true;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;

        waypointIndex++;
    }

    private void Update()
    {
        if (isMovingRight)
        {
            MoveTo();
        }
        else
        {
            MoveTo();
        }
    }

    private void MoveTo()
    {
        var targetPosition = waypoints[waypointIndex].transform.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            if (waypointIndex + 1 >= waypoints.Count || waypointIndex - 1 < 0)
            {
                isMovingRight = !isMovingRight;

                transform.RotateAround(transform.position, transform.up, 180f);
            }

            if (isMovingRight)
            {
                waypointIndex++;
            }
            else
            {
                waypointIndex--;
            }
        }

    }
}
