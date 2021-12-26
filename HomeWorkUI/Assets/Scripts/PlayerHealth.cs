using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   private int destroyPower = 500;
   public void DestroyPlayer()
   {
      GameManger.instance.ReduseHealth(destroyPower);
   }
}
