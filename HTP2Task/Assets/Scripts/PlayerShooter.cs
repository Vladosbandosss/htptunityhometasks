using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
   [SerializeField] private GameObject bulletPrefab;

   [SerializeField] private Transform spawnPosition;

    void Update()
    {
       Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, spawnPosition.position, Quaternion.identity);
        }
    }
}
