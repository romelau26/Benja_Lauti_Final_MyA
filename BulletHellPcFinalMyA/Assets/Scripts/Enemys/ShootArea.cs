using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArea : MonoBehaviour
{
    public Transform[] Spawns;
    float ShootRateTime = 0;
    public float shootRate = 0.5f;
    private void Update()
    {
        if (Time.time > ShootRateTime) //coldown de disparo
        {
            ShootRateTime = Time.time + shootRate;
            Shoot();
        }
    }
    void Shoot() //Factory y Pool
    {
        for (int i = 0; i < Spawns.Length; i++)
        {
            var b = FactoryEnemy.Instance.GetObj();
            b.transform.position = Spawns[i].position;
            b.transform.forward = Spawns[i].forward;
        }

    }
}
