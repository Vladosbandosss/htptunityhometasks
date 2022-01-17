using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RotateScripts : MonoBehaviour
{
   [SerializeField] private float minRotateSpedd = 100f, maxRotateSpeed = 150f;

   private float rotateSpeed = 100f;

   [SerializeField] private bool setSpeed;

   [SerializeField] private bool rotateX, rotateY, rotateZ;

   private void Awake()
   {
      if (setSpeed)
      {
         rotateSpeed = Random.Range(minRotateSpedd, maxRotateSpeed);
      }
   }

   private void Update()
   {
      if (rotateX)
      {
         transform.Rotate(Vector3.right*Time.deltaTime*rotateSpeed);
      }
      
      if (rotateY)
      {
         transform.Rotate(Vector3.up*Time.deltaTime*rotateSpeed);
      }
      
      if (rotateZ)
      {
         transform.Rotate(Vector3.forward*Time.deltaTime*rotateSpeed);
      }
   }
}
