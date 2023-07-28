using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] GameObject[] _ships;
    [SerializeField] float _initialTime;
    [SerializeField] int _currentShipsWave;
    [SerializeField] Vector3 _spawnZone;

    int _maxCantShips;
    int _currentCantShips;
    float _spawnTime;
    GameObject _gameObject;

    private void Start()
    {
        _spawnTime = _initialTime;
    }
    private void Update()
    {
        WaveGenerator();
    }

    void WaveGenerator()
    {
        _spawnTime -= 1 * Time.deltaTime;

        if (_spawnTime <= 0 &&  _maxCantShips < _currentShipsWave)
        {
            Debug.Log("Spawnea nave");
            _spawnZone.x = Random.Range(-60f, 60f);
            _gameObject = Instantiate(_ships[Random.Range(0, _ships.Length)], _spawnZone, transform.rotation);
            _maxCantShips++;
            _spawnTime = _initialTime;
        }
    }

}
