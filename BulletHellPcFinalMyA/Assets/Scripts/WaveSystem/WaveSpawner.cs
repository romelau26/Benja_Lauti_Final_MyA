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
    [SerializeField] int WaveCount;
    public Wave[] waves;
    private int nextWave = 0;
    public float TimerBetweenWaves;//puede ser 1 minuto entre cada oleada
    float WaveCountDown = 0f;
    private SpawnStates state = SpawnStates.Counting;
    private float searchCountDown=1f;
    private int shipboss = 0;
    [SerializeField] Vector3 _spawnZone;
    public Transform boss;//los tipos de enemigos que se van a crear
    public GameObject AllGame;//los tipos de enemigos que se van a crear
    private void Start()
    {
        WaveCountDown = TimerBetweenWaves;
    }
    private void Update()
    {
        if(WaveCount<10 && shipboss==0)
        {
            if (state == SpawnStates.Waiting)
            {
                if (!EnemyisAlive())
                {
                    OleadaCompletada();
                }
                else
                {
                    Debug.Log("hay enemigos vivos");
                    return;
                }
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


        if(WaveCount>=10 && shipboss==0)
        {
            StopAllCoroutines();
            SpawnBoss(boss);
            shipboss++;
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
    public void SpawnEnemys(Transform[] _enemy)//si queres spawnear otro enemigo arega otro if y pone enemy[al numero en el que esta el nuevo enemigo]
    {
        _spawnZone.x = Random.Range(-60f, 60f);
        int numenemyProbability = Random.Range(0, 101);
        if(numenemyProbability>=0 && numenemyProbability<=50)
        {
            //Instantiate(_enemy[0], _spawnZone, transform.rotation);
            Transform hijoInstanciado = Instantiate(_enemy[0], _spawnZone, transform.rotation);
            hijoInstanciado.SetParent(AllGame.transform);
        }
        else if(numenemyProbability > 50 && numenemyProbability <= 75)
        {
            //Instantiate(_enemy[1], _spawnZone, transform.rotation);
            Transform hijoInstanciado = Instantiate(_enemy[1], _spawnZone, transform.rotation);
            hijoInstanciado.SetParent(AllGame.transform);
        }
        else if(numenemyProbability > 75 && numenemyProbability <= 101)
        {
            Transform hijoInstanciado = Instantiate(_enemy[2], _spawnZone, transform.rotation);
            hijoInstanciado.SetParent(AllGame.transform);
        }
    }
    public void SpawnBoss(Transform _Boss)
    {
        _spawnZone.x = Random.Range(-60f, 60f);
        Instantiate(_Boss, _spawnZone, transform.rotation);
    }
}
