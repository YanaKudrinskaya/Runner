using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_enemyPrefabs);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject enemy))
            _elapsedTime = 0;
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);

        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
