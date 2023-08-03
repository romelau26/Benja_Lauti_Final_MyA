using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossShip : BasicStats
{
    [SerializeField] float _radius;
    [SerializeField] float _changeStateWhen;
    [SerializeField] GameObject[] _waypoints;

    [Header("BULLET")]
    public GameObject bulletPrefab;
    [SerializeField] float _shootTime;
    [SerializeField] Transform[] _shootPoints;
    float _currentShootTime;
    [SerializeField] GameObject _particlePrefab;
    int _currentWaypoint;
    IMovement _linarMovement;
    IMovement _finalAttack;
    IMovement _currentMovement;

    private void Start()
    {
        _linarMovement = new LinearMovement(transform, _movementSpeed, _waypoints, _currentWaypoint, _radius);
        _finalAttack = new FinalAttack(transform, _movementSpeed);
        _currentShootTime = _shootTime;
        CurrentHealth = MaxHealth;
        _waypoints[0] = GameObject.FindGameObjectWithTag("A");
        _waypoints[1] = GameObject.FindGameObjectWithTag("B");
    }
    private void Update()
    {
        if (CurrentHealth <= _changeStateWhen)
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
                InstanceBullet(_shootPoints[0]);
                _currentShootTime = _shootTime;
            }
        }
        if(CurrentHealth<=0)
        {
            gameObject.SetActive(false);
            ParticleFxBuilder();
            MoveScenes();
        }
        if(_currentMovement == _finalAttack)
        {
            _currentShootTime -= 1 * Time.deltaTime;
            if (_currentShootTime <= 0)
            {
                InstanceBullet(_shootPoints[0]);
                InstanceBullet(_shootPoints[1]);
                InstanceBullet(_shootPoints[2]);
                InstanceBullet(_shootPoints[3]);
                InstanceBullet(_shootPoints[4]);
                InstanceBullet(_shootPoints[5]);
                InstanceBullet(_shootPoints[6]);
                InstanceBullet(_shootPoints[7]);
                _currentShootTime = _shootTime;
            }
        }
    }

    public void InstanceBullet(Transform spawn)
    {
        var b = FactoryEnemy.Instance.GetObj();
        b.transform.position = spawn.position;
        b.transform.forward = spawn.forward;
    }
    public void ParticleFxBuilder()
    {
        GameObject particle = new ParticleBuilder(_particlePrefab)
                              .SetPos(transform.position)
                              .SetScale(Vector3.one)
                              .Done();
    }
    public void MoveScenes() { SceneManager.LoadScene("Win"); }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_waypoints[_currentWaypoint].transform.position, _radius);
    }
}
