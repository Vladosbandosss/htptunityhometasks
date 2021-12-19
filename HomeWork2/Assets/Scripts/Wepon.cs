using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    [SerializeField]  Camera _fpsCamera;
    [SerializeField] private float _rangeShoot = 100f;

    [SerializeField] private float _damage;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _pointToShoot;
    
    private void Update()
    {
        if (Input.GetButtonDown(TagManger.SHOOTMOUSECLICK))
        {
            ShootRay();
        }

        if (Input.GetButtonDown("Fire2"))
        {
           // ShootBollet();потом допилю
        }
    }

    private void ShootRay()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _rangeShoot))
        {
            if (hit.transform.CompareTag(TagManger.ENEMYTAG))
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                target.TakeDamage(_damage);
            }

        }
      
    }

    private void ShootBollet()
    {
        Instantiate(_bulletPrefab, _pointToShoot.position, Quaternion.identity);
    }
}
