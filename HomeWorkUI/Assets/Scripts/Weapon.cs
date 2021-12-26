using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float range = 100;

    [SerializeField] private int damage = 60;

    [SerializeField] private int bullets = 10;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")&&bullets>0)
        {
            bullets--;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameManger.instance.ReduseAmmo();
        
        RaycastHit hit;
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null)
            {
                return;
            }
            
            target.TakeDamage(damage);
        }
        
    }
}
