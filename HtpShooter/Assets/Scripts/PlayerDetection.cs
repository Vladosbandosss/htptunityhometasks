using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(TagManger.PLAYERTAG))
        {
            SceneManager.LoadScene(TagManger.SCENENAME);
        }
    }
}
