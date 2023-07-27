using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Player : BasicStats
{
    [Header ("LIFE")]
    public Image[] ships;
    public Sprite FullLife;
    public Sprite VoidLife;

    [Space] [Space]

    [SerializeField] GameObject DeadImage;
    [SerializeField] GameObject ShieldObj;
    [SerializeField] TMP_Text LifeTimerText;
    [SerializeField] TMP_Text _ScoreUI;
    [SerializeField] float _LifeTime;
    float TimerBuff;
    [SerializeField] float MaxTimerBuff;
    public static int ScoreAmount;
    public int MinGetLife;//le puse una cantidad minima para que consigas una vida mas
    private int Minutes, Seconds, Cents;
    public Transform PosSpawn1,PosSpawn2,PosSpawn3;
    Vector3 _movedirection;
    public float shootRate;
    bool leftOnClick = false;
    public bool TripleShoot = false;
    public bool NormalShoot = false;
    public bool Shield = false;

    [Header("PARTICULAS")]
    [SerializeField] GameObject _particlePrefab;
    [SerializeField] Transform _spawnPoint;

    private void Start()
    {
        TimerBuff = MaxTimerBuff;
        CurrentHealth = MaxHealth;
        NormalShoot = true;
        ShieldObj.SetActive(false);
    }
    private void Update()
    {
        LogicMovement();
        LimitsFronts();
        ScoreUI();
        LifePlayerUI();
        if(CurrentHealth >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                leftOnClick = true;
                if(NormalShoot)
                {
                    StartNormalShoot();
                }
                if (TripleShoot)
                {
                    StartTripleShoot();
                }


            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                leftOnClick = false;
                if(NormalShoot)
                {
                    StopNormalShoot();
                }
                if (TripleShoot)
                {
                    StopTripleShoot();
                }

            }
            LifeTimeUI();
        }
        else
        {
            Dead();
        }
        if (TripleShoot)
        {
            TimerTripleShoot();
        }
        if(Shield)
        {
            ActiveShield();
        }
    }
    //esto va en view
    public void LifePlayerUI()
    {
        foreach (Image imag in ships)
        {
            imag.sprite = VoidLife;
        }
        for (int i = 0; i < CurrentHealth; i++)
        {
            ships[i].sprite = FullLife;
        }
    }
    public void LifeTimeUI()
    {
        _LifeTime += Time.deltaTime;
        Minutes = (int)(_LifeTime / 60f);
        Seconds = (int)(_LifeTime - Minutes * 60f);
        Cents = (int)((_LifeTime - (int)_LifeTime) * 100);
        LifeTimerText.text = string.Format("{0:00}:{1:00}:{2:00}",Minutes, Seconds, Cents);
    }
    public void ScoreUI()
    {
        _ScoreUI.text = "" + ScoreAmount.ToString("0");
        if(CurrentHealth<MaxHealth && ScoreAmount>=MinGetLife)
        {
            ScoreAmount -= MinGetLife;
            CurrentHealth += 1;
        }
    }
    #region DeadMethod
    public void Dead()
    {
        DeadImage.SetActive(true);
        gameObject.SetActive(false);
        ParticleFxBuilder();
    }
    #endregion
    //esto va en control
    #region MovementLogic
    public void LogicMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _movedirection = new Vector3(h, 0, v);
        transform.position += _movementSpeed * Time.deltaTime * _movedirection;
    }
    #endregion
    //esto va en model
    public void LimitsFronts()
    {
        transform.position = GameManager.Instance.transportPosition(transform.position);
    }
    #region Buffs
    #region Shield
    public void ActiveShield()
    {
        TimerBuff -= 1 * Time.deltaTime;
        if (TimerBuff <= 0.1f)
        {
            ShieldObj.SetActive(false);
            TimerBuff = MaxTimerBuff;
        }
        else
        {
            ShieldObj.SetActive(true);
        }
    }
    #endregion
    #region TripleShoot
    public void TimerTripleShoot()
    {
        TimerBuff -= 1 * Time.deltaTime;
        if (TimerBuff <= 0.1f)
        {
            TripleShoot = false;
            NormalShoot = true;
            TimerBuff = MaxTimerBuff;
        }
    }
    public void StartTripleShoot()
    {
        InvokeRepeating(nameof(Shoot1), 0, shootRate);
        InvokeRepeating(nameof(Shoot2), 0, shootRate);
        InvokeRepeating(nameof(Shoot3), 0, shootRate);
    }
    public void StopTripleShoot()
    {
        CancelInvoke(nameof(Shoot1));
        CancelInvoke(nameof(Shoot2));
        CancelInvoke(nameof(Shoot3));
    }
    #endregion
    #endregion
    #region Shoot
    public void StartNormalShoot()//para instanciar el disparo normal
    {
        InvokeRepeating(nameof(Shoot1), 0, shootRate);
    }
    public void StopNormalShoot()//para dejar de instanciar el disparo normal
    {
        CancelInvoke(nameof(Shoot1));
    }
    public void Shoot1()
    {
        var b = factorypool.Instance.GetObj();
        b.transform.position = PosSpawn1.position;
        b.transform.forward = PosSpawn1.forward;
    }
    public void Shoot2()
    {
        var b = factorypool.Instance.GetObj();
        b.transform.position = PosSpawn2.position;
        b.transform.forward = PosSpawn2.forward;
    } 
    public void Shoot3()
    {
        var b = factorypool.Instance.GetObj();
        b.transform.position = PosSpawn3.position;
        b.transform.forward = PosSpawn3.forward;
    }
    #endregion

    public void ParticleFxBuilder()
    {
        GameObject particle = new ParticleBuilder(_particlePrefab)
                              .SetPos(_spawnPoint.position)
                              .SetScale(Vector3.one)
                              .Done();
    }
}
