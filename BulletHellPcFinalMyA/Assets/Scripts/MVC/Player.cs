using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasicStats
{
    [SerializeField] GameObject ParticleObj;
    public Transform PosSpawn1,PosSpawn2,PosSpawn3;
    Vector3 _movedirection;
    public float shootRate;
    public bool leftOnClick = false;
    public bool TripleShoot = false;
    private void Update()
    {
        LogicMovement();
        LimitsFronts();
        if(CurrentHealth >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                leftOnClick = true;
                if (TripleShoot)
                {
                    StartTripleShoot();
                }
                else
                {
                    StartNormalShoot();
                }

            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                leftOnClick = false;
                if (TripleShoot)
                {
                    StopTripleShoot();
                }
                else
                {
                    StopNormalShoot();
                }

            }
        }
        else
        {
            Dead();
        }

    }
    //esto va en model
    public void LimitsFronts()
    {
        transform.position = GameManager.Instance.transportPosition(transform.position);
    }
    #region DeadMethod
    public void Dead()
    {
        gameObject.SetActive(false);
        Instantiate(ParticleObj, transform.position, transform.rotation);
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
    #region Shoots
    #region NormalShootInvoke
    public void StartNormalShoot()//para instanciar el disparo normal
    {
        InvokeRepeating(nameof(Shoot1), 0, shootRate);
    }
    public void StopNormalShoot()//para dejar de instanciar el disparo normal
    {
        CancelInvoke(nameof(Shoot1));
    }
    #endregion
    #region TripleShoot
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
}
