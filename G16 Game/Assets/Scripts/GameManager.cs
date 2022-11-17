using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        resetCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoins(int scoreToAdd)
    {
        coins += scoreToAdd;
        Debug.Log(coins);
        //SetCoinText();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void spendCoins(int num)
    {
        coins = num;
    }

    private void resetCoins()
    {
        coins = 0;
    }
}
