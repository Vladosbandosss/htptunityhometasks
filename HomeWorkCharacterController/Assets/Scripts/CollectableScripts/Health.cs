using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

     [SerializeField] private GameObject healthFX;

     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag(TagManager.PLAYERTAG))
          {
               other.GetComponent<HealthManger>().IncreaseHealth();
               Instantiate(healthFX, transform.position, Quaternion.identity);
               Destroy(gameObject);
          }
     }
}
