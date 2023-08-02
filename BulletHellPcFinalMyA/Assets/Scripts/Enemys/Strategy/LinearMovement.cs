using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : IMovement
{
    Transform _bossShip;
    Transform[] _waypoints;
    int _currentWaypoint;
    float _speed;
    float _radius;

    public LinearMovement(Transform bossShip, float speed, Transform[] waypoints, int currentWaypoint, float radius)
    {
        _bossShip = bossShip;
        _speed = speed;
        _waypoints = waypoints;
        _currentWaypoint = currentWaypoint;
        _radius = radius;
    }

    public void Movement()
    {
        Vector3 dir = _waypoints[_currentWaypoint].transform.position - _bossShip.position;
        dir.Normalize();
        _bossShip.position += dir * _speed * Time.deltaTime;

        if (dir.magnitude <= _radius)
            Debug.Log("A");
        if (_currentWaypoint >= _waypoints.Length)
            _currentWaypoint = 0;
    }
}