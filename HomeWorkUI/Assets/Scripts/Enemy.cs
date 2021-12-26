using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float minMoveSpeed = 0.5f, maxMoveSpeed = 2f;

    private float moveSpeed;

    [SerializeField] private float minDistance = 1f;

    private float distance;

    private Transform playerTarget;

    private void Start()
    {
        playerTarget = GameObject.FindWithTag(TagManger.PLAYERTAG).transform;
        
        SetMoveSped();
    }

    private void Update()
    {
        if (!playerTarget)
        {
            return;
        }
        
        transform.LookAt(playerTarget);

        distance = Vector3.Distance(transform.position, playerTarget.position);

      
        if (distance > minDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

   private void SetMoveSped()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }
}