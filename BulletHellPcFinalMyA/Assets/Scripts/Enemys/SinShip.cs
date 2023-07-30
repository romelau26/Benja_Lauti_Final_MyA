using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinShip : BasicStats
{
    [SerializeField] int MinScore;
    [SerializeField] int MaxScore;
    [SerializeField] float RangeSin;


    [Header("PARTICULAS")]
    [SerializeField] GameObject _particlePrefab;

    [Header("FEEDBACK")]
    public CameraShake cameraShake;
    [SerializeField] float _shakeDuration;
    [SerializeField] float _shakeMagnitude;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        _particlePrefab = GameObject.FindGameObjectWithTag("EnemyExplosion");
        cameraShake = GameObject.FindObjectOfType<CameraShake>();
    }

    void Update()
    {
        if (CurrentHealth<=0)
        {
            StartCoroutine(cameraShake.Shake(_shakeDuration, _shakeMagnitude));
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
                              .SetPos(transform.position)
                              .SetScale(Vector3.one)
                              .Done();
    }
}
