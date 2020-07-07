using System.Collections.Generic;
using UnityEngine;

public class SpaceShipPathing : MonoBehaviour
{
    [SerializeField]
    private List<Transform> waypoints;
    [SerializeField]
    private float movingSpeed = 10f;

    private int waypointIndex = 0;

    private bool isMovingRight;
    private bool isRightMainDirection;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;

        isMovingRight = (transform.position - waypoints[waypointIndex + 1].transform.position).x < 0;

        isRightMainDirection = isMovingRight;

        waypointIndex++;

        if (!isRightMainDirection)
        {
            RotateShipToDirection();
        }

    }

    private void Update()
    {
        MoveTo();
    }

    private void MoveTo()
    {
        var targetPosition = waypoints[waypointIndex].transform.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movingSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            if (waypointIndex + 1 >= waypoints.Count || waypointIndex - 1 < 0)
            {
                isMovingRight = !isMovingRight;

                RotateShipToDirection();
            }

            if (isMovingRight == isRightMainDirection)
            {
                waypointIndex++;
            }
            else
            {
                waypointIndex--;
            }
        }
    }

    private void RotateShipToDirection()
    {
        transform.RotateAround(transform.position, transform.up, 180f);
    }

}
