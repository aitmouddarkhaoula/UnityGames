using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemiesB : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _powerUpPrefab;
    [SerializeField] private float _spawnRange = 9f;
    private int SpawnCount=4;
    
    void Start()
    {
        //InvokeRepeating(nameof(SpawnEnemy), 0, Random.Range(1f, 3f));
        SpawnEnemy(SpawnCount);
    }

    public void SpawnEnemy(int SpawnCount)
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            Instantiate(_enemyPrefab, GetRandomPosition(), _enemyPrefab.transform.rotation, transform);  
        }

        for (int i = 0; i < SpawnCount / 3; i++)
        {
            Instantiate(_powerUpPrefab, GetRandomPosition(), _powerUpPrefab.transform.rotation, transform);
        }
        
    }

    private void Update()
    {
        int enemyCount = FindObjectsOfType<EnemyFollow>().Length;
        if(enemyCount==0)
            SpawnEnemy(SpawnCount++);
    }

    public Vector3 GetRandomPosition()
    {
        float posX = Random.Range(-_spawnRange, _spawnRange);
        float posZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 position = new Vector3(posX, 0, posZ);
        return position;
    }
   
}
