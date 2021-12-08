using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    private Vector3 spawnPos;
    private float minX = -100f, maxX = 100f;
    private float minY = 5f, maxY = 10f;
    private float minZ = -100f, maxZ = 100f;
    private bool canCreate = true;
    
    void Start()
    {
        StartCoroutine(nameof(SpawningPlatforms));
    }

    void CreatePlatform()
    {
      float randomX = Random.Range(minX, maxX);
      float randomY = Random.Range(minY, maxY);
      float randomZ = Random.Range(minZ, maxZ);

      Vector3 randomPos = new Vector3(randomX, randomY, randomZ);

      Instantiate(platform, randomPos, Quaternion.identity);
      //StartCoroutine(nameof(SpawningPlatforms));
     
    }

    IEnumerator SpawningPlatforms()
    {
        while (canCreate)
        {
            yield return new WaitForSeconds(5f);
            CreatePlatform();
        } 
    }
}
