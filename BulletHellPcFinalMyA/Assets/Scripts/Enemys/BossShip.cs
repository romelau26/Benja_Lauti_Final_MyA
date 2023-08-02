using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : MonoBehaviour
{
    [SerializeField] float _movementSpeed;
    [SerializeField] float _radius;
    [SerializeField] float _life;
    [SerializeField] float _changeStateWhen;
    [SerializeField] Transform[] _waypoints;

    [Header("BULLET")]
    public GameObject bulletPrefab;
    [SerializeField] float _shootTime;
    [SerializeField] List<Transform> _shootPoints = new List<Transform>();
    float _currentShootTime;

    int _currentWaypoint;
    IMovement _linarMovement;
    IMovement _finalAttack;
    IMovement _currentMovement;

    private void Awake()
    {
        _linarMovement = new LinearMovement(transform, _movementSpeed, _waypoints, _currentWaypoint, _radius);
        _finalAttack = new FinalAttack(transform, _movementSpeed);
        _currentShootTime = _shootTime;
    }

    private void Update()
    {
        if (_life <= _changeStateWhen)
        {
            _currentMovement = _finalAttack;
            Shoot();
        }
        else
        {
            _currentMovement = _linarMovement;
            Shoot();
        }

        _currentMovement.Movement();
    }

    void Shoot()
    {
        if(_currentMovement == _linarMovement)
        {
            _currentShootTime -= 1 * Time.deltaTime;
            if(_currentShootTime <= 0)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                _currentShootTime = _shootTime;
            }
        }

        if(_currentMovement == _finalAttack)
        {
            _currentShootTime -= 1 * Time.deltaTime;
            if (_currentShootTime <= 0)
            {
                foreach (var point in _shootPoints)
                {
                    Instantiate(bulletPrefab, point.transform.position, point.transform.rotation);
                    _currentShootTime = _shootTime;
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_waypoints[_currentWaypoint].transform.position, _radius);
    }
}
