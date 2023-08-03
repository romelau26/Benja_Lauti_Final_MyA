using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinShip : BasicStats
{
    [SerializeField] float RangeSin;
    [SerializeField] int damageForCollision;
    [Header("PARTICULAS")]
    [SerializeField] GameObject _particlePrefab;

    [Header("FEEDBACK")]
    public CameraShake cameraShake;
    [SerializeField] float _shakeDuration;
    [SerializeField] float _shakeMagnitude;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        cameraShake = GameObject.FindObjectOfType<CameraShake>();
    }
    void Update()
    {
        LimitsFronts();
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
            //Player player = FindObjectOfType<Player>();
            View player = FindObjectOfType<View>();
            var ValuePoints = Random.Range(50, 101);
            player.AddPoints(ValuePoints);
        }
    }
    public void LimitsFronts()
    {
        transform.position = GameManager.Instance.transportPositionEnemy(transform.position);
    }
    public void ParticleFxBuilder()
    {
        GameObject particle = new ParticleBuilder(_particlePrefab)
                              .SetPos(transform.position)
                              .SetScale(Vector3.one)
                              .Done();
    }
}
