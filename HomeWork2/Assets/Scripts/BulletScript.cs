using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BulletScript : MonoBehaviour
{
   private Rigidbody _rb;
   [SerializeField] private float _forceZ=10f;
   
   private void Awake()
   {
      _rb = GetComponent<Rigidbody>();
      
   }

   private void FixedUpdate()
   {
       //_rb.MovePosition(transform.position+transform.forward*_forceZ*Time.fixedDeltaTime);
     //_rb.velocity = new Vector3(0, 0, _forceZ);
     //_rb.AddRelativeForce(transform.forward,ForceMode.Impulse);
     //_rb.AddForce(transform.forward*_forceZ*Time.fixedDeltaTime);
     
     //_rb.velocity = transform.TransformDirection(Vector3.forward * _forceZ);
   }
}
