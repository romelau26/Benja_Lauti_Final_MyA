using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : IMovement
{
    Transform _bossShip;
    GameObject[] _waypoints;
    int _currentWaypoint;
    float _speed;
    float _radius;

    public LinearMovement(Transform bossShip, float speed, GameObject[] waypoints, int currentWaypoint, float radius)
    {
        _bossShip = bossShip;
        _speed = speed;
        _waypoints = waypoints;
        _currentWaypoint = currentWaypoint;
        _radius = radius;
    }

    public void Movement()
    {
        if(Vector3.Distance(_bossShip.position,_waypoints[_currentWaypoint].transform.position)<0.1f)
        {
            _currentWaypoint++;
            if(_currentWaypoint>=_waypoints.Length)
            {
                _currentWaypoint = 0;
            }
        }
        _bossShip.position = Vector3.MoveTowards(_bossShip.position, _waypoints[_currentWaypoint].transform.position,_speed*Time.deltaTime);
    }
}