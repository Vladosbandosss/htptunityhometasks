using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
 [Header("Mouse Sensivity")] 
 [SerializeField] [Range(100f, 200f)] private float mouseSensivityXAxis = 150f;
 [SerializeField] [Range(100f, 200f)] private float mouseSensivityYAxis = 130f;

 [SerializeField] private Transform playerControllerTransform;
 
 [SerializeField] private Transform cameraTransform;


 [Header("CameraXRotation")]
 [SerializeField] [Range(-60f, -40f)] private float minCameraXRotationAngle = -50f;
 [SerializeField] [Range(40f, 60f)] private float maxCameraXRotationAngle = 50f;

 private Vector2 inputValue;
 private  Vector3 tempAngles=Vector3.zero;


 private void Start()
 {
  Cursor.lockState = CursorLockMode.Locked;
 }

 private void Update()
 {
  GetPlayerInput();
  LookAtX();
  LookAtY();
 }
 
 void GetPlayerInput()
 {
  float mouseXInput = Input.GetAxis(TagManager.MOUSEX) * mouseSensivityXAxis * Time.deltaTime;
  float mouseYInput = Input.GetAxis(TagManager.MOUSEY) * mouseSensivityYAxis * Time.deltaTime;

  inputValue = new Vector2(mouseXInput, mouseYInput);//считали x и  y мышки и в вектор запихнули
 }
 void LookAtX()
 {
  playerControllerTransform.Rotate(new Vector3(0f,inputValue.x,0f));//так как камера на игроке то игрок вращ и камера с ним
 }

 void LookAtY()
 {
  tempAngles.x -= inputValue.y;
  tempAngles.x = Mathf.Clamp(tempAngles.x, minCameraXRotationAngle, maxCameraXRotationAngle);
  cameraTransform.localRotation=Quaternion.Euler(tempAngles);//по x camera вращается с ограничениями
 }


}//class
