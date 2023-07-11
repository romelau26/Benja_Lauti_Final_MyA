using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public GameObject[] Enemys;
    public int WaveCount;
    public int Wave;
    public int EnemyType;
    public bool SpawnIng;
    private int EnemysSpawned;
    // Start is called before the first frame update
    void Start()
    {
        WaveCount = 2;
        Wave = 1;
        SpawnIng = false;
        EnemysSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(SpawnIng==false)
    }
}
