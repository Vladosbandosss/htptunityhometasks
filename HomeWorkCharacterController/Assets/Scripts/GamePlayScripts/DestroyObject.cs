using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
   private float timer = 2f;

   [SerializeField] private bool shouldDestroy;


   private void Start()
   {
      Invoke(nameof(DeactivateObject),timer);
   }

   void DeactivateObject()
   {
      if (shouldDestroy)
      {
         Destroy(gameObject);
      }
      else
      {
         gameObject.SetActive(false);
      }
   }
}
