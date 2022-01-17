using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject pichUpFX;

    private void Start()
    {
        GamePlayManager.instance.SetCoinCount(1);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.PLAYERTAG))
        {
            AudioManger.instnace.PlaySound(SFX.CoinPickUp);
            Instantiate(pichUpFX, transform.position, Quaternion.identity);
           GamePlayManager.instance.SetCoinCount(-1);

            Destroy(gameObject);
        }
    }
}
