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
    public Text shopCoinsText;
    //public Image progressBarFillMask;
    private int coins = 0;
    private int kills = 0;
    private float progressTracker = 0;

    //Current level for upgrades
    private int currentSpeedLevel;
    private int currentAttackLevel;
    private int currentJumpLevel;
    private int currentSpellLevel;
    private int currentMultiplierLevel;
    private int currentRockSteadyLevel;

    //Max level for upgrades
    private int maxSpeedUpgrade = 10;
    private int maxJumpUpgrade = 10;
    private int maxMultiplierUpgrade = 10;
    private int maxRockSteadyUpgrade = 1;

    //Current cost for upgrades
    public int currentSpeedCost;
    public int currentAttackCost;
    public int currentJumpCost;
    public int currentSpellCost;
    public int currentMultiplierCost;
    public int currentRockSteadyCost;

    public Button buttonSpeedUpgrade;
    public Button buttonJumpUpgrade;
    public Button buttonMultiplierUpgrade;
    public Button buttonRockSteadyUpgrade;
    public Button buttonAttackUpgrade;
    public Button buttonSpellUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        resetCoins();
        SetCoinText();
        resetKills();
        resetCostAndLevels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoins(int scoreToAdd)
    {
        coins += scoreToAdd;
        //Debug.Log(coins);
        SetCoinText();
  
    }

    private void setProgresss()
    {
        //progressBarFillMask.fillAmount = progressTracker / 30;
        //Debug.Log("progress: " + progressBarFillMask.fillAmount);
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
        //setProgresss();
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

    public bool spendOnSpeed()
    {
        if ((coins - currentSpeedCost) >= 0)
        {
            coins -= currentSpeedCost;
            currentSpeedCost = ((int)(currentSpeedCost * 2.5));
            currentSpeedLevel += 1;
            if(currentSpeedLevel >= maxSpeedUpgrade)
            {
                buttonSpeedUpgrade.interactable = false;
            }
            SetCoinText();
            return true;
        }
        else
        {
            coinsText.color = Color.red;
            return false;
        }
    }

    public void spendOnAttack()
    {
        if ((coins - currentAttackCost) >= 0)
        {
            coins -= currentSpeedCost;
            currentAttackCost = ((int)(currentAttackCost * 2.5));
            SetCoinText();
        }
        else
        {
            coinsText.color = Color.red;
        }
    }
    public void spendOnJump()
    {
        if ((coins - currentJumpCost) >= 0)
        {
            coins -= currentJumpCost;
            currentJumpCost = ((int)(currentJumpCost * 2.5));
            SetCoinText();
        }
        else
        {
            coinsText.color = Color.red;
        }
    }

    public void spendOnSpell()
    {
        if ((coins - currentSpellCost) >= 0)
        {
            coins -= currentSpellCost;
            currentSpellCost = ((int)(currentSpellCost * 2.5));
            SetCoinText();
        }
        else
        {
            coinsText.color = Color.red;
        }
    }
    public void spenOnMultiplier()
    {
        if ((coins - currentMultiplierCost) >= 0)
        {
            coins -= currentMultiplierCost;
            GameManager.instance.spendCoins(GameManager.instance.currentMultiplierCost);
            SetCoinText();
        }
        else
        {
            coinsText.color = Color.red;
        }
    }
    public void spendOnRockSteady()
    {
        if ((coins - currentRockSteadyCost) >= 0)
        {
            coins -= currentRockSteadyCost;
            SetCoinText();
        }
        else
        {
            coinsText.color = Color.red;
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
        shopCoinsText.text = "Coins: " + coins.ToString();
    }

    public void resetCostAndLevels()
    {
        currentSpeedCost = 5;
        currentAttackCost = 5;
        currentJumpCost = 5;
        currentSpellCost = 10;
        currentMultiplierCost = 50;
        currentRockSteadyCost = 500;

        currentSpeedLevel = 0;
        currentAttackLevel = 0;
        currentJumpLevel = 0;
        currentSpellLevel = 0;
        currentMultiplierLevel = 0;
        currentRockSteadyLevel = 0;
}
    
    public bool isRockSteady()
    {
        return (currentRockSteadyLevel < maxRockSteadyUpgrade);
    }
}
