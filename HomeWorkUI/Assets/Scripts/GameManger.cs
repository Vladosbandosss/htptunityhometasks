using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
   public static GameManger instance;

   [SerializeField] private Text healthText;
   private int health=100;

   [SerializeField] private Text bulletsText;
   private int bullets = 10;

   [SerializeField] private GameObject goPanel;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }

      healthText.text="Health:"+health;
      bulletsText.text = "Bullets" + bullets;
   }

   public void ReduseAmmo()
   {
      bullets--;
      bulletsText.text = "Bullets" + bullets;
   }

   public void ReduseHealth(int enemyDamage)
   {
      health -= enemyDamage;

      if (health <= 0)
      {
         healthText.text = "Health:0";
         ShowGOPanel();
      }
      else
      {
         healthText.text="Health:"+health;
      }
   }

   private void ShowGOPanel()
   {
      Time.timeScale = 0f;
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
      goPanel.SetActive(true);
   }
}
