using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveIntentoLauti : MonoBehaviour
{
    [SerializeField] Transform[] enemysPrefab;
    [SerializeField] Vector3 _spawnZone;
    [SerializeField] float TimeBetweenWaves=5f;
    [SerializeField] TMP_Text WaveText;
    private float CountDown=2f;
    private int WaveIndex=0;
    void Update()
    {
        if(CountDown<=0f)
        {
            StartCoroutine(SpawnWave());
            CountDown = TimeBetweenWaves;
        }
        CountDown -= 1f * Time.deltaTime;
        WaveText.text = Mathf.Round(WaveIndex).ToString();
    }
    IEnumerator SpawnWave()
    {
        WaveIndex++;
        for (int i = 0; i < WaveIndex; i++)
        {
            SpawnEnemys();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void SpawnEnemys()
    {
        _spawnZone.x = Random.Range(-60f, 60f);
        for (int i = 0; i < enemysPrefab.Length; i++)//lo q hago es instanciar un enemigo aleatorio en una posicion aleatoria 
        {
            int numEnemyProbability = Random.Range(0, 101);//tipo de enemigo dependiendo de la probabilidad
            if(numEnemyProbability>=0&& numEnemyProbability<=40)
            {
                Instantiate(enemysPrefab[0], _spawnZone, transform.rotation);
            }
            else if(numEnemyProbability>40&&numEnemyProbability<=50)
            {
                Instantiate(enemysPrefab[1], _spawnZone, transform.rotation);
            }
        }
    }
}
