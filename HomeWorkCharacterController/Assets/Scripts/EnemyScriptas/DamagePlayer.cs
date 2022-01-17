using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
   [SerializeField] private bool isDeadZone;
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag(TagManager.PLAYERTAG))
      {
         if (isDeadZone)
         {
            other.GetComponent<HealthManger>().DamagePlayer(100);
         }
         else
         {
            other.GetComponent<HealthManger>().DamagePlayer(1);
         }
      }
   }
}
