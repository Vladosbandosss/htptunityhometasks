using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
   
    private float playerSpeed = 0.5f;
    private float rotationSpeed = 4f;
    
    private float moveHorizontal;
    private float moveVertical;

    private float rotationZ;
    public float rotationY;
    private float moveUpspeed = 10f;

    private float zSpeedRotation = 20f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rotationY = transform.localRotation.eulerAngles.y;
    }

    private void Update()
    {
        PlayerMoveKeyBoard();
    }

    private void MovementUpDown()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rb.velocity = new Vector3(0f, -moveUpspeed, 0f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rb.velocity = new Vector3(0f, moveUpspeed, 0f);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        MoveAndRotate();
        
        MovementUpDown();
    }

    void PlayerMoveKeyBoard()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveHorizontal = -1f;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            moveHorizontal = 0f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveHorizontal = 1f;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            moveHorizontal = 0f;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveVertical = 1f;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            moveVertical = 0f;
        }
    }

    void MoveAndRotate()
    {
        if (moveVertical != 0)
        {
            rb.MovePosition(transform.position + transform.forward * (moveVertical * playerSpeed));
        }

        
        if (moveHorizontal == 0)
        {
            rotationZ = Mathf.Lerp(rotationZ, 0f, Time.deltaTime * rotationSpeed);
        }
        
        rotationZ += moveHorizontal * rotationSpeed*-1f*Time.deltaTime*zSpeedRotation;
        
        if (rotationZ > 20f)
        {
            rotationZ = 20f;
        }

        if (rotationZ < -20f)
        {
            rotationZ = -20f;
        }
        
        rotationY += moveHorizontal * rotationSpeed;
        rb.rotation = Quaternion.Euler(0f, rotationY, rotationZ);
      
    }

}
