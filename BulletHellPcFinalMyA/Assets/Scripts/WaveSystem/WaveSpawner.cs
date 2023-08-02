using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public enum SpawnStates { Spawning, Waiting, Counting }

    [System.Serializable]
    public class Wave
    {
        public string name;//nombre de la oleada
        public Transform[] enemy;//los tipos de enemigos que se van a crear
        public int Count;//la cantidad de enemigos
        public float rate=1;//la diferencia de tiempo entre cada enemigo creado
    }
    //visual
    [SerializeField] TMP_Text WaveText;
    private int WaveCount;
    public Wave[] waves;
    private int nextWave = 0;
    public float TimerBetweenWaves;//puede ser 1 minuto entre cada oleada
    float WaveCountDown = 0f;
    private SpawnStates state = SpawnStates.Counting;
    private float searchCountDown=1f;
    [SerializeField] Vector3 _spawnZone;
    private void Start()
    {
        WaveCountDown = TimerBetweenWaves;
    }
    private void Update()
    {
        if(state==SpawnStates.Waiting)
        {
            if(!EnemyisAlive())
            {
                OleadaCompletada();
            }
            else
            {
                Debug.Log("hay enemigos vivos");
                return;
            }
        }
        if(WaveCountDown<=0)
        {
            if(state!=SpawnStates.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            WaveCountDown -= Time.deltaTime;
        }
    }

    bool EnemyisAlive()
    {
        searchCountDown -= Time.deltaTime;
        if(searchCountDown<=0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    public void OleadaCompletada()
    {
        Debug.Log("oleada completada");
        state = SpawnStates.Counting;
        WaveCountDown = TimerBetweenWaves;
        if(nextWave+1>waves.Length-1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }

    }
    IEnumerator SpawnWave(Wave _wave)
    {
        WaveCount++;
        WaveText.text = "" + WaveCount.ToString("0");
        state = SpawnStates.Spawning;
        for (int i = 0; i < _wave.Count; i++)
        {
            SpawnEnemys(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = SpawnStates.Waiting;
        yield break;
    }
    public void SpawnEnemys(Transform[] _enemy)
    {
        _spawnZone.x = Random.Range(-60f, 60f);
        int numenemyProbability = Random.Range(0, 101);
        if(numenemyProbability>=0 && numenemyProbability<=60)
        {
            Instantiate(_enemy[0], _spawnZone, transform.rotation);
        }
        else if(numenemyProbability > 60 && numenemyProbability <= 85)
        {
            Instantiate(_enemy[1], _spawnZone, transform.rotation);
        }
        else if(numenemyProbability>85 && numenemyProbability<=95)
        {
            Instantiate(_enemy[2], _spawnZone, transform.rotation);
        }
    }
}
