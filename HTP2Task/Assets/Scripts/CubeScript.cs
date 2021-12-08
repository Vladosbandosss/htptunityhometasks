using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private float timeBeforeDie = 10f;
    
    void Start()
    {
        Invoke(nameof(Die),timeBeforeDie);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
           // GameManger.instance.IncreaseScore();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
