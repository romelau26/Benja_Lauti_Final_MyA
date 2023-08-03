using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuffs : MonoBehaviour
{
    public GameObject[] objetosASpawnear;
    public float tiempoEntreSpawns = 5f;
    public int objetosSpawned = 0;
    private int maxObjetosEnEscena = 1;
    private float XposSpawn;
    private float ZposSpawn;
    private void Start()
    {
        
    }
    private void Update()
    {
        StartCoroutine(SpawnObject());
    }
    private IEnumerator SpawnObject()
    {

            if (objetosSpawned < maxObjetosEnEscena)
            {
                XposSpawn = Random.Range(-57, 58);
                ZposSpawn = Random.Range(-33, 38);
                int SelectedBuff = Random.Range(0, objetosASpawnear.Length);
                Instantiate(objetosASpawnear[SelectedBuff], new Vector3(XposSpawn, 2, ZposSpawn), Quaternion.identity);
                objetosSpawned++;
            }
            yield return new WaitForSeconds(tiempoEntreSpawns);
        
    }
}

