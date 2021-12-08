using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    
    private Text textScore;
    private int score=0;

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
    }

    void Start()
    {
        //textScore = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log(score);
        textScore.text = score.ToString();
    }

    
}
