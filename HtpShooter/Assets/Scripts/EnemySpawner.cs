using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    
    [SerializeField] private float minSpawnPos = -50f, maxSpawnPos = 50f;

    [SerializeField] private float minYpos = 5f, maxYpos = 15f;
    
    [SerializeField] private float minSpawnTime = 3f, maxSpawnTime = 6f;
    
    private float spawnTimer;
    
    private Vector3 spawnPos;
    
    private void Update()
    {
        CheckToSpawnEnemy();
    }
    
   private void CheckToSpawnEnemy()
    {
        if (Time.time > spawnTimer)
        {
            spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
            SpawnEnemy();
        }
    }
   
  private void SpawnEnemy()
   {
        spawnPos = new Vector3(Random.Range(minSpawnPos, maxSpawnPos),
        Random.Range(minYpos, maxYpos),
       Random.Range(minSpawnPos, maxSpawnPos));
        
       Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        
      
   }
}
