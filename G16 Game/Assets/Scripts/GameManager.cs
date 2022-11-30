using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject upgradeMenu;
    public Text coinsText;
    public Image progressBarFillMask;
    private int coins = 0;
    private int kills = 0;
    private float progressTracker = 0;

    // Start is called before the first frame update
    void Start()
    {
        resetCoins();
        SetCoinText();
        resetKills();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoins(int scoreToAdd)
    {
        coins += scoreToAdd;
        Debug.Log(coins);
        SetCoinText();
  
    }

    private void setProgresss()
    {
        progressBarFillMask.fillAmount = progressTracker / 30;
        Debug.Log("progress: " + progressBarFillMask.fillAmount);
    }


    public void AddKill()
    {
        kills += 1;
        progressTracker += 1;
        if(progressTracker == 30) // 30
        {
            Time.timeScale = 0;
            upgradeMenu.SetActive(true);
        }
        setProgresss();
    }

    public IEnumerator progressResetWait()
    {
        yield return new WaitForSeconds(1.0f);
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

    public void spendCoins(int spend)
    {
        if((coins - spend) >= 0)
        {
            coins -= spend;
            SetCoinText();
        }
        else
        {
            coinsText.color = Color.red;
            progressResetWait();
            //coinsText.color = Color.white;
        }
    }

    private void resetCoins()
    {
        coins = 0;
    }

    private void resetKills()
    {
        kills = 0;
    }

    public void resetProgress()
    {
        progressTracker = 0;
        coinsText.color = Color.white;
        setProgresss();
    }

    void SetCoinText()
    {
        coinsText.text = ": " + coins.ToString();
    }
}
