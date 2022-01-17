using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManger : MonoBehaviour
{
   [SerializeField] private GameObject [] robotParts;

   [SerializeField] private GameObject robot;

   [SerializeField] private int maxHealth = 3;
   private int health;

   [SerializeField] private GameObject deathFX;

   [SerializeField] private float invisibleDuration = 2f;
   private float invisibleTimer;

   private PlayerMovement _playerMovement;

   private void Awake()
   {
      health = maxHealth;
      _playerMovement = GetComponent<PlayerMovement>();
   }


   private void Update()
   {
      MakeRobotInvisible();
   }

   void MakeRobotInvisible()
   {
      if (invisibleTimer > 0f)
      {
         invisibleTimer -= Time.deltaTime;

         bool isVisible = Mathf.Floor(invisibleTimer * 5f) % 2 == 0 || invisibleTimer <= 0f;

         for (int i = 0; i < robotParts.Length; i++)
         {
            robotParts[i].SetActive(isVisible);
         }
      }
   }

   public void DamagePlayer(int damageAmmount)
   {
      if (invisibleTimer > 0)
      {
         return;
      }

      health -= damageAmmount;

      if (health <= 0)
      {
        GamePlayManager.instance.GameOver();
         PlayerDied();
      }
      else
      {
         AudioManger.instnace.PlaySound(SFX.TakeDamage);
         invisibleTimer = invisibleDuration;
        _playerMovement.KnockBack();
         
        GamePlayManager.instance.SetHealthCount(-1);

      }
      
   }

   public void IncreaseHealth()
   {
      if (health < maxHealth)
      {
         health++;
        GamePlayManager.instance.SetHealthCount(+1);
      }
      AudioManger.instnace.PlaySound(SFX.HeartPickUp);
      
   }

   void PlayerDied()
   {
      robot.SetActive(false);
      AudioManger.instnace.PlaySound(SFX.Death);
      Instantiate(deathFX, transform.position, Quaternion.identity);
   }
}
