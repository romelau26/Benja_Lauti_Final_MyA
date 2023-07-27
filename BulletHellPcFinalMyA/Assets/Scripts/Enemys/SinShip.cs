using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinShip : BasicStats
{
    [SerializeField] Transform finalPos;
    [SerializeField] int MinScore;
    [SerializeField] int MaxScore;
    [SerializeField] float RangeSin;
    IAdvance _currentPlan;
    IAdvance _SinMove;

    [Header("PARTICULAS")]
    [SerializeField] GameObject _particlePrefab;
    [SerializeField] Transform _spawnPoint;

    private void Start()
    {
        _SinMove = new MovementSin(this.transform, RangeSin);
        CurrentHealth = MaxHealth;
    }
    void Update()
    {
        if (CurrentHealth<=0)
        {
            gameObject.SetActive(false);
            ParticleFxBuilder();
            var ValueMoney = Random.Range(MinScore, MaxScore);
            Player.ScoreAmount += ValueMoney;
        }
    }
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.z -= _movementSpeed * Time.fixedDeltaTime;
        transform.position = pos;
    }

    public void ParticleFxBuilder()
    {
        GameObject particle = new ParticleBuilder(_particlePrefab)
                              .SetPos(_spawnPoint.position)
                              .SetScale(Vector3.one)
                              .Done();
    }
}
