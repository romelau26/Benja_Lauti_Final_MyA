using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuffs : MonoBehaviour
{
    public int MaxBuffs;
    public int CurrentBuff;
    private float XposSpawn;
    private float ZposSpawn;
    public GameObject [] Buffs;
    public float MaxTimer;
    public float Currenttimer;


    void Start()
    {
        Currenttimer = MaxTimer;
    }

    void Update()
    {
        if (CurrentBuff != MaxBuffs)
        {
            Currenttimer += 1f * Time.deltaTime;
            if (Currenttimer >= MaxTimer)
            {
                XposSpawn = Random.Range(-57, 58);
                ZposSpawn = Random.Range(-33, 38);
                int SelectedBuff = Random.Range(0, Buffs.Length);
                Instantiate(Buffs[SelectedBuff], new Vector3(XposSpawn, 0, ZposSpawn), Buffs[SelectedBuff].transform.rotation);
                CurrentBuff++;
                Currenttimer = MaxTimer;
            }
        }
    }
}
