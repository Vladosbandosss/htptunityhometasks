﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(TagManger.PLAYERTAG))
        {
           other.gameObject.GetComponent<PlayerHealth>().DestroyPlayer();
        }
    }
}
