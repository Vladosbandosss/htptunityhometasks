using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingBlocks : MonoBehaviour
{
    private enum  BlockState
    {
        Fall,
        Reset,
        Idle
    }

    private BlockState _blockState = BlockState.Idle;

    private float fallTime;

    [SerializeField] private float fallDistace = 3.5f;//с 5.5 до 2 упадут(на мост)

    [SerializeField] private float fallPower = 6f;

    [SerializeField] private float idleDuration = 1f;

    [SerializeField] private float resetDuration = 2f;

    private Vector3 startPos, endPos;

    private void Start()
    {
        startPos = transform.position;
        endPos = transform.position - new Vector3(0f, fallDistace, 0f);
    }

    private void Update()
    {
        switch (_blockState)
        {
            case  BlockState.Fall:
                
                fallTime += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, endPos, Mathf.Pow(fallTime, fallPower));

                if (transform.position == endPos)
                {
                    _blockState = BlockState.Reset;
                    fallTime = 0f;
                }
                break;
            case  BlockState.Reset:
                
                fallTime += Time.deltaTime / resetDuration;
                transform.position = Vector3.Lerp(endPos, startPos, fallTime);

                if (transform.position == startPos)
                {
                    _blockState = BlockState.Idle;
                    fallTime = 0f;
                }
                break;
            case BlockState.Idle:

                fallTime += Time.deltaTime;

                if (fallTime > idleDuration)
                {
                    idleDuration = Random.Range(1f, 2f);
                    _blockState = BlockState.Fall;
                    fallTime = 0f;
                }
                break;
        }
    }
}//class
