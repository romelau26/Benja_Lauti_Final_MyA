using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetraEnemy : BasicStats
{
    [Header("BULLETS")]
    public float shootTime;
    public float shootDelay;
    [SerializeField] Transform[] _shootPointsOrder;
    [SerializeField] GameObject _bulletPrefab;

    Transform _currentShootPoint;
    int _currentIDPoint;
    float _currentShootTime;

    private void Awake()
    {
        _currentShootTime = shootTime;
        _currentIDPoint = 0;
        CurrentHealth = MaxHealth;
        _currentShootPoint = _shootPointsOrder[_currentIDPoint];
        _bulletPrefab = GameObject.FindGameObjectWithTag("Ball_EnemyBullet");
    }

    private void Update()
    {
        transform.position += (new Vector3(0, 0, -1) * _movementSpeed) * Time.deltaTime;
        Shoot();
        if (CurrentHealth <= 0) Destroy(this.gameObject);
    }

    void Shoot()
    {
        _currentShootTime -= 1 * Time.deltaTime;

        if(_currentShootTime <= 0)
        {
            _currentShootPoint = _shootPointsOrder[_currentIDPoint];
            Vector3 spawn = _shootPointsOrder[_currentIDPoint].transform.position;
            Instantiate(_bulletPrefab, spawn, Quaternion.identity);
            _currentIDPoint++;
            if (_currentIDPoint >= _shootPointsOrder.Length)
            {
                _currentIDPoint = 0;
                _currentShootTime = shootDelay;
            } 
            else _currentShootTime = shootTime;
        }
    }

    //public void FactoryShoot(Vector3 spawn)
    //{
    //    var b = BallEnemy_PF.Instance.GetObj();
    //    b.transform.position = spawn;
    //    b.transform.forward = spawn;
    //}
}
