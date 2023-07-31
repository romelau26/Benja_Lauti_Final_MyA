using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinShip : BasicStats
{
    [SerializeField] int MinScore;
    [SerializeField] int MaxScore;
    [SerializeField] float RangeSin;
    [SerializeField] Player pl;

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
        if(CurrentHealth>0)
        {
            Vector3 pos = transform.position;
            pos.z -= _movementSpeed * Time.deltaTime;
            transform.position = pos;
        }
        if (CurrentHealth<=0)
        {
            StartCoroutine(cameraShake.Shake(_shakeDuration, _shakeMagnitude));
            gameObject.SetActive(false);
            ParticleFxBuilder();
            if(pl.DoblePoints==true)
            {
                var ValueMoney = Random.Range(MinScore, MaxScore);
                Player.ScoreAmount += ValueMoney * 2;
            }
            else
            {
                var ValueMoney = Random.Range(MinScore, MaxScore);
                Player.ScoreAmount += ValueMoney;
            }


        }
    }

    public void ParticleFxBuilder()
    {
        GameObject particle = new ParticleBuilder(_particlePrefab)
                              .SetPos(transform.position)
                              .SetScale(Vector3.one)
                              .Done();
    }
}
