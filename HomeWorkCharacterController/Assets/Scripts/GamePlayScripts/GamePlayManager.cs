using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;

    public bool playerDied;
    
    private int coinCount;
    private Text coinScoreText;

    [SerializeField] private GameObject[] healthUi;

    [SerializeField] private int initialHelath = 2;

    private int healthCount;

    private void Awake()
    {
        instance = this;
        coinScoreText = GameObject.FindWithTag(TagManager.COINTEXTTAG).GetComponent<Text>();
        healthCount = initialHelath;
    }

    public void GameOver()
    {
        playerDied = true;
        RestartGame();
    }

    void RestartGame()
    {
        Invoke(nameof(NewGame),2f);
    }

    void NewGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SetCoinCount(int coinValue)
    {
        coinCount += coinValue;
        coinScoreText.text = coinCount.ToString();
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public void SetHealthCount(int healthvalue)
    {
        if (healthvalue < 0)
        {
            healthUi[healthCount].SetActive(false);
            healthCount += healthvalue;
            
        }else if (healthCount > 0)
        { healthCount += healthvalue;
            healthUi[healthCount].SetActive(true);
        }
    }
}
