using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform playerTarget;

    private float _moveSpeed = 5f;
    
    private void Start()
    {
        playerTarget = GameObject.FindWithTag(TagManger.PLAYERTAG).transform;
    }

    private void Update()
    {
        transform.LookAt(playerTarget);
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }
}
