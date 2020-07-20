using System.Collections.Generic;
using UnityEngine;

public class SpaceShipPathing : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _waypoints;
    [SerializeField]
    private float _movingSpeed = 10f;

    private int _waypointIndex = 0;

    private bool _isMovingRight;
    private bool _isRightMainDirection;

    private void Start()
    {
        transform.position = _waypoints[_waypointIndex].transform.position;

        _isMovingRight = (transform.position - _waypoints[_waypointIndex + 1].transform.position).x < 0;

        _isRightMainDirection = _isMovingRight;

        _waypointIndex++;

        if (!_isRightMainDirection)
        {
            RotateShipToDirection();
        }
    }

    private void Update() => MoveTo();

    private void MoveTo()
    {
        Vector3 targetPosition = _waypoints[_waypointIndex].transform.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _movingSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            if (_waypointIndex + 1 >= _waypoints.Count || _waypointIndex - 1 < 0)
            {
                _isMovingRight = !_isMovingRight;

                RotateShipToDirection();
            }

            if (_isMovingRight == _isRightMainDirection)
            {
                _waypointIndex++;
            }
            else
            {
                _waypointIndex--;
            }
        }
    }

    private void RotateShipToDirection() => transform.RotateAround(transform.position, transform.up, 180f);
}
