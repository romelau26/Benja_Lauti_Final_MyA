using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerModel : BasicStats
{
    //[Header("LIFE")]




    //[SerializeField] GameObject ShieldObj;
    //float TimerBuff;
    //[SerializeField] float MaxTimerBuff;
    //public Transform PosSpawn1, PosSpawn2, PosSpawn3, PosSpawn4, PosSpawn5, PosSpawn6, PosSpawn7, PosSpawn8;
    //Vector3 _movedirection;
    //public float shootRate;
    //float ShootRateTime = 0;
    //public bool TripleShoot = false;//bufo de triple tiro
    //public bool NormalShoot = false;//tiro normal
    //public bool MultipleShoot = false;//tiro multiple
    //public bool Shield = false;//se active el bufo del escudo q te da inmunidad
    //public bool DoblePoints = false;//para que los puntos q consigas sean dobles

    //[Header("PARTICULAS")]
    //[SerializeField] GameObject _particlePrefab;
    //[SerializeField] Transform _spawnPoint;

    //[Header("FEEDBACK")]
    //public CameraShake cameraShake;
    //[SerializeField] float _shakeDuration;
    //[SerializeField] float _shakeMagnitude;
    //public static int ScoreAmount;
    //private void Start()
    //{
    //    TimerBuff = MaxTimerBuff;
    //    CurrentHealth = MaxHealth;
    //    NormalShoot = true;
    //    ShieldObj.SetActive(false);
    //}
    //private void Update()
    //{
    //    LogicMovement();
    //    LimitsFronts();
    //    //ScoreUI();                //esto esta en el view
    //    //LifePlayerUI();
    //    if (CurrentHealth >= 1)
    //    {
    //        if (Input.GetMouseButton(0))
    //        {
    //            if (NormalShoot)
    //            {
    //                StartNormalShoot();
    //            }
    //            if (TripleShoot)
    //            {
    //                StartTripleShoot();
    //            }
    //            if (MultipleShoot)
    //            {
    //                StartMultipleShoot();
    //            }
    //        }
    //        //LifeTimeUI(); //esto esta en el view tiene que llevarse al update
    //    }
    //    else
    //    {
    //        Dead();
    //    }
    //    if (TripleShoot)
    //    {
    //        TimerTripleShoot();
    //    }
    //    if (MultipleShoot)
    //    {
    //        TimerMultiplehoot();
    //    }
    //    if (Shield)
    //    {
    //        ActiveShield();
    //    }
    //    if (DoblePoints)
    //    {
    //        DoblePointsTime();
    //    }
    //}
    ////esto va en view
    //public void AddPoints(int Pointsadd)
    //{
    //    if (DoblePoints)
    //    {
    //        Pointsadd *= 2;
    //    }
    //    ScoreAmount += Pointsadd;
    //}
    //#region DeadMethod
    //public void Dead()
    //{
    //    DeadImage.SetActive(true);
    //    gameObject.SetActive(false);
    //    ParticleFxBuilder();
    //}
    //#endregion
    //public void ParticleFxBuilder()
    //{
    //    GameObject particle = new ParticleBuilder(_particlePrefab)
    //                          .SetPos(_spawnPoint.position)
    //                          .SetScale(Vector3.one)
    //                          .Done();
    //}
    ////esto va en control
    //#region MovementLogic
    //public void LogicMovement()
    //{
    //    float h = Input.GetAxisRaw("Horizontal");
    //    float v = Input.GetAxisRaw("Vertical");
    //    _movedirection = new Vector3(h, 0, v);
    //    transform.position += _movementSpeed * Time.deltaTime * _movedirection;
    //}
    //#endregion
    ////esto va en model y algunas cosas en el view
    //public void LimitsFronts()
    //{
    //    transform.position = GameManager.Instance.transportPosition(transform.position);
    //}
    //#region Buffs
    //#region Shield
    //public void ActiveShield()
    //{
    //    TimerBuff -= 1 * Time.deltaTime;
    //    if (TimerBuff <= 0.1f)
    //    {
    //        Shield = false;
    //        ShieldObj.SetActive(false);
    //        ShieldUI.SetActive(false);
    //        TimerBuff = MaxTimerBuff;
    //    }
    //    else
    //    {
    //        ShieldUI.SetActive(true);
    //        ShieldObj.SetActive(true);
    //    }
    //}
    //#endregion
    //#region TripleShoot
    //public void TimerTripleShoot()
    //{
    //    TimerBuff -= 1 * Time.deltaTime;
    //    if (TimerBuff <= 0.1f)
    //    {
    //        TripleShootUI.SetActive(false);
    //        TripleShoot = false;
    //        NormalShoot = true;
    //        TimerBuff = MaxTimerBuff;
    //    }
    //}
    //public void StartTripleShoot()
    //{
    //    if (Time.time > ShootRateTime) //coldown de disparo
    //    {
    //        TripleShootUI.SetActive(true);
    //        ShootRateTime = Time.time + shootRate;
    //        Shoot(PosSpawn1);
    //        Shoot(PosSpawn2);
    //        Shoot(PosSpawn3);
    //    }
    //    StartCoroutine(cameraShake.Shake(_shakeDuration, _shakeMagnitude));
    //}
    //#endregion
    //#region MultipleShoot
    //public void TimerMultiplehoot()
    //{
    //    TimerBuff -= 1 * Time.deltaTime;
    //    if (TimerBuff <= 0.1f)
    //    {
    //        MultipleShootUI.SetActive(false);
    //        MultipleShoot = false;
    //        NormalShoot = true;
    //        TimerBuff = MaxTimerBuff;
    //    }
    //}
    //public void StartMultipleShoot()
    //{
    //    if (Time.time > ShootRateTime) //coldown de disparo
    //    {
    //        MultipleShootUI.SetActive(true);
    //        ShootRateTime = Time.time + shootRate;
    //        Shoot(PosSpawn1);
    //        Shoot(PosSpawn2);
    //        Shoot(PosSpawn3);
    //        Shoot(PosSpawn4);
    //        Shoot(PosSpawn5);
    //        Shoot(PosSpawn6);
    //        Shoot(PosSpawn7);
    //        Shoot(PosSpawn8);
    //    }
    //    StartCoroutine(cameraShake.Shake(_shakeDuration, _shakeMagnitude));
    //}
    //#endregion
    //#region DoblePoints
    //public void DoblePointsTime()
    //{
    //    TimerBuff -= Time.deltaTime;
    //    if (TimerBuff <= 0.1f)
    //    {
    //        TimerBuff = MaxTimerBuff;
    //        DoblePointsUI.SetActive(false);
    //        DoblePoints = false;
    //    }
    //    else
    //    {
    //        DoblePointsUI.SetActive(true);
    //    }
    //}
    //#endregion
    //#endregion
    //#region Shoot
    //public void StartNormalShoot()//para instanciar el disparo normal
    //{
    //    if (Time.time > ShootRateTime) //coldown de disparo
    //    {
    //        ShootRateTime = Time.time + shootRate;
    //        Shoot(PosSpawn1);
    //    }
    //    StartCoroutine(cameraShake.Shake(_shakeDuration, _shakeMagnitude));
    //}
    //public void Shoot(Transform spawn)
    //{
    //    var b = factorypool.Instance.GetObj();
    //    b.transform.position = spawn.position;
    //    b.transform.forward = spawn.forward;
    //}
    //#endregion
}
