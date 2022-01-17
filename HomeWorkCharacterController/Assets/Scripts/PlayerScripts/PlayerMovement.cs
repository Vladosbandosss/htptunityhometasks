using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField] private float movementSpeed = 5f;

    [Header("Gravity options")] 
    [SerializeField] [Range(-80f, 0f)] private float gravityScale = -40f;
    [SerializeField] [Range(2f, 30f)] private float jumpHeight = 5f;

    [Header("Ground Options")] 
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckradius=0.2f;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Button Options")] 
    [SerializeField] private string jumpButton = "Jump";

    private Vector3 movementDirection;
    private Vector3 verticalVelocity;
    
    private bool _canDoubleJump;
    private bool _isGrounded;
    
    public  bool CanDoubleJump
    {
        get { return _canDoubleJump; }
        set { _canDoubleJump = value; }
    }

    public bool IsGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }

    private PlayerAnimation _playerAnim;

    [SerializeField] private GameObject model;

    private Camera mainCam;

    [SerializeField] private float rotateSpeed = 5f;


    private bool isKnockedBack;

    [SerializeField] private float knockBackPower = 3f;

    [SerializeField] private float knockBackDuration = 0.5f;

    private float knockBackTimer;

    private void Awake()
    {
        _playerAnim = GetComponent<PlayerAnimation>();
        _characterController = GetComponent<CharacterController>();
        mainCam=Camera.main;
    }

    private void Update()
    {
        if (GamePlayManager.instance.playerDied)
        {
            return;
        }
        GroundCheck();
        
        if (isKnockedBack)
        {
            CalculateKnockBackMotion();
        }
        else
        {
            HorizontalMovement();
            VerticalMovement();
        }
       
        
        Jump();
        AnimatePlayer();
    }

    void GroundCheck()
    {
        IsGrounded = Physics.CheckSphere(groundCheckTransform.position, groundCheckradius, whatIsGround);
    }

    void HorizontalMovement()
    {
        float horizontalInput = Input.GetAxis(TagManager.HORIZONTALAXIS);
        float verticalInput = Input.GetAxis(TagManager.VERTICALAXIS);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection = transform.TransformDirection(movementDirection);//с локала по мировой

        _characterController.Move(movementDirection * movementSpeed * Time.deltaTime);//двигаем
        RotateRobot(horizontalInput,verticalInput);
    }
    
    void RotateRobot(float horizontalInput, float verticalInput)
    {
        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.rotation=Quaternion.Euler(0f,mainCam.transform.rotation.eulerAngles.y,0f);
            model.transform.rotation=Quaternion.Slerp(model.transform.rotation,
                Quaternion.LookRotation(new Vector3(movementDirection.x,0f,movementDirection.z)),rotateSpeed*Time.deltaTime);
        }
    }
    
    void VerticalMovement()
    {
        if (IsGrounded && verticalVelocity.y < 0f)
        {
            verticalVelocity.y = 0f;
        }
        else
        {
            verticalVelocity.y += gravityScale * Time.deltaTime;
        }

        _characterController.Move(verticalVelocity * Time.deltaTime);
    }

    void Jump()
    {
        if (IsGrounded && Input.GetButtonDown(jumpButton))
        {
            verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravityScale);
            CanDoubleJump = true;
           AudioManger.instnace.PlaySound(SFX.Jump);
        }else if (Input.GetButtonDown(jumpButton) && CanDoubleJump)
        {
            CanDoubleJump = false;
            verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravityScale);
            AudioManger.instnace.PlaySound(SFX.Jump);
        }
    }

    void AnimatePlayer()
    {
        _playerAnim.PlayRun(Mathf.Abs(movementDirection.x)+Math.Abs(movementDirection.z));
        _playerAnim.PlayJump(IsGrounded);
    }

    void CalculateKnockBackMotion()
    {
        knockBackTimer -= Time.deltaTime;
        isKnockedBack = knockBackTimer > 0;

        movementDirection = _characterController.transform.forward * -knockBackPower;
    }

    public void KnockBack()
    {
        isKnockedBack = true;
        knockBackTimer = knockBackDuration;
    }

}//class
