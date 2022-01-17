using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum SkeletonState
{
    Idle,
    Patrol,
    Chase,
    Attack
}

public class Skeleton : MonoBehaviour
{
    [SerializeField] private Transform[] patrolpoints; //точки патрола индекса запихнуть
    private int patrolPointIndex=0;

    private NavMeshAgent _navAgent;

    [SerializeField] private Animator _anim;

    private SkeletonState skeletonState;

    [SerializeField] private float waitAtPoint = 1f;

    [SerializeField] private float chaseRange = 5f;

    [SerializeField] private float attackRange = 0.7f;

    [SerializeField] private float attackDelay = 2f;

    [SerializeField] private float rotationSpeed = 3f;

    private float waitAtPointTimer, attackDelayTimer;

    private Transform playerTarget;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindWithTag(TagManager.PLAYERTAG).transform;

    }

    private void Update()
    {
        if (GamePlayManager.instance.playerDied)
        {
            _navAgent.isStopped = true;
            Idle(10000);
            return;
        }
        float distanceToPlayr = Vector3.Distance(playerTarget.position, _navAgent.transform.position);

        switch (skeletonState)
        {
            case SkeletonState.Idle:
                Idle(distanceToPlayr);
                break;
            case SkeletonState.Patrol:
                Patrol(distanceToPlayr);
                break;
            case SkeletonState.Chase:
                Chase(distanceToPlayr);
                break;
            case SkeletonState.Attack:
                Attack(distanceToPlayr);
                break;

        }
    }

    void LookAtSlerp(Transform target)
        {
            _navAgent.transform.rotation = Quaternion.Slerp
            (_navAgent.transform.rotation, Quaternion.LookRotation
                (target.transform.position - _navAgent.transform.position), Time.deltaTime * rotationSpeed);

            _navAgent.transform.rotation = Quaternion.Euler(0f, _navAgent.transform.rotation.eulerAngles.y, 0f);

        }

        void Idle(float distanceToPlayer)
        {
            if (distanceToPlayer <= chaseRange)
            {
                skeletonState = SkeletonState.Chase;
            }
            else
            {
                _anim.SetBool(TagManager.MOVEANIMATIONPARAMETR, false);

                if (waitAtPointTimer > 0f)
                {
                    waitAtPointTimer -= Time.deltaTime;
                }
                else
                {
                    skeletonState = SkeletonState.Patrol;
                    _navAgent.SetDestination(patrolpoints[patrolPointIndex].position);
                }
            }
        }

        void Patrol(float distanceToPlayer)
        {
            if (distanceToPlayer <= chaseRange)
            {
                skeletonState = SkeletonState.Chase;
            }
            else
            {
                LookAtSlerp(patrolpoints[patrolPointIndex]);
                bool isMoving = true;
                if (_navAgent.remainingDistance <= 0.2f)
                {
                    patrolPointIndex++;
                    if (patrolPointIndex == patrolpoints.Length)
                    {
                        patrolPointIndex = 0;
                    }

                    skeletonState = SkeletonState.Idle;
                    waitAtPointTimer += waitAtPoint;
                    isMoving = false;
                }

                _anim.SetBool(TagManager.MOVEANIMATIONPARAMETR, isMoving);
            }
        }

        void Chase(float distanceToPlayer)
        {
            LookAtSlerp(playerTarget);
            _navAgent.SetDestination(playerTarget.position);

            bool isMoving = true;
            if (distanceToPlayer <= attackRange)
            {
                skeletonState = SkeletonState.Attack;
                isMoving = false;
                _anim.SetTrigger(TagManager.ATTACKANIMATIONPARAMETR);

                _navAgent.velocity = Vector3.zero;
                _navAgent.isStopped = true;

                attackDelayTimer = attackDelay;
            }
            else if (distanceToPlayer > chaseRange)
            {
                skeletonState = SkeletonState.Patrol;
                waitAtPointTimer = waitAtPoint;
                _navAgent.velocity = Vector3.zero;
            }

            _anim.SetBool(TagManager.MOVEANIMATIONPARAMETR, isMoving);
        }

        void Attack(float distanceToPlayer)
        {
            LookAtSlerp(playerTarget);

            attackDelayTimer -= Time.deltaTime;

            if (attackDelayTimer <= 0)
            {
                if (distanceToPlayer <= attackRange)
                {
                    _anim.SetTrigger(TagManager.ATTACKANIMATIONPARAMETR);
                    attackDelayTimer = attackDelay;
                }
                else
                {
                    skeletonState = SkeletonState.Idle;
                    _navAgent.isStopped = false;
                }
            }
           
        }





    
} //class
