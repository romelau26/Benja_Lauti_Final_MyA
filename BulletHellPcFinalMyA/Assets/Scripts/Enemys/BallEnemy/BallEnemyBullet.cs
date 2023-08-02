using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemyBullet : HitBox
{
    private void Awake()
    {
        _currentLifeTime = MaxLifetime;
    }

    private void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
        _currentLifeTime -= Time.deltaTime;
        if (_currentLifeTime <= 0) Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        BasicStats hithalth = other.GetComponent<BasicStats>();

        if (hithalth != null && other.CompareTag("Player"))
        {
            hithalth.ReciveDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}
