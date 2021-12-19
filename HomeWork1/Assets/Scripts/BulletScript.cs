using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerController _playerController;

    private float bulletYrotation;
    private float speed = 2f;
    private float timeToDestroy = 3f;
   
    
    
    private void Awake()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        bulletYrotation = _playerController.rotationY;
    }

    private void Start()
    {
        Invoke(nameof(DestroyBullet),timeToDestroy);
    }

    private void Update()
    {
        BulletMovement();
    }

    private void BulletMovement()
    {
        rb.rotation = Quaternion.Euler(0f, bulletYrotation, 0f);
        rb.MovePosition(transform.position + transform.forward * speed);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
