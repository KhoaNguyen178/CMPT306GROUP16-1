using Packages.Rider.Editor.UnitTesting;
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

    public Text textSpeedLevel, textSpeedCost;
    public Text textAttackLevel, textAttackCost;
    public Text textRockSteadyLevel, textRockSteadyCost;
    public Text textMultiplierLevel, textMultiplierCost;
    public Text textSpellLevel, textSpellCost;
    public Text textJumpLevel, textJumpCost;

    public Transform pfDamagePopup;
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
            checkButtons();
            SetCoinText();
            return true;
        }
        else
        {
            coinsText.color = Color.red;
            shopCoinsText.color = Color.white;
            return false;
        }
    }

    public bool spendOnAttack()
    {
        if ((coins - currentAttackCost) >= 0)
        {
            coins -= currentAttackCost;
            currentAttackCost = ((int)(currentAttackCost * 2.5));
            currentAttackLevel += 1;
            //can infinitely upgrade attack damage
            checkButtons();
            SetCoinText();
            return true;
        }
        else
        {
            coinsText.color = Color.red;
            shopCoinsText.color = Color.white;
            return false;
        }
    }
    public bool spendOnJump()
    {
        if ((coins - currentJumpCost) >= 0)
        {
            coins -= currentJumpCost;
            currentJumpCost = ((int)(currentJumpCost * 2.5));
            currentJumpLevel += 1;
            if (currentJumpLevel >= maxJumpUpgrade)
            {
                buttonJumpUpgrade.interactable = false;
            }
            checkButtons();
            SetCoinText();
            return true;
        }
        else
        {
            coinsText.color = Color.red;
            shopCoinsText.color = Color.white;
            return false;
        }
    }

    public bool spendOnSpell()
    {
        if ((coins - currentSpellCost) >= 0)
        {
            coins -= currentSpellCost;
            currentJumpCost = ((int)(currentSpellCost * 2.5));
            currentSpellLevel += 1;
            //can infinitely upgrade spell damage
            checkButtons();
            SetCoinText();
            return true;
        }
        else
        {
            coinsText.color = Color.red;
            shopCoinsText.color = Color.white;
            return false;
        }
    }
    public bool spendOnMultiplier()
    {
        if ((coins - currentMultiplierCost) >= 0)
        {
            coins -= currentMultiplierCost;
            currentMultiplierCost = ((int)(currentMultiplierCost * 2.5));
            currentMultiplierLevel += 1;
            if (currentMultiplierLevel >= maxMultiplierUpgrade)
            {
                buttonMultiplierUpgrade.interactable = false;
            }
            checkButtons();
            SetCoinText();
            return true;
        }
        else
        {
            coinsText.color = Color.red;
            shopCoinsText.color = Color.white;
            return false;
        }
    }
    public bool spendOnRockSteady()
    {
        if ((coins - currentRockSteadyCost) >= 0)
        {
            coins -= currentRockSteadyCost;
            currentRockSteadyCost = ((int)(currentRockSteadyCost * 2.5));
            currentRockSteadyLevel += 1;
            if (currentRockSteadyLevel >= maxRockSteadyUpgrade)
            {
                buttonRockSteadyUpgrade.interactable = false;
            }
            checkButtons();
            SetCoinText();
            return true;
        }
        else
        {
            coinsText.color = Color.red;
            shopCoinsText.color = Color.white;
            return false;
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

    public void resetButtons()
    {
        coinsText.color = Color.white;
        buttonSpeedUpgrade.interactable = true;
        buttonJumpUpgrade.interactable = true;
        buttonMultiplierUpgrade.interactable = true;
        buttonRockSteadyUpgrade.interactable = true;
        buttonAttackUpgrade.interactable = true;
        buttonSpellUpgrade.interactable = true;
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

    public void checkButtons()
    {
        if(coins < currentSpeedCost)
        {
            buttonSpeedUpgrade.interactable = false;
        }
        if (coins < currentJumpCost)
        {
            buttonJumpUpgrade.interactable = false;
        }
        if (coins < currentMultiplierCost)
        {
            buttonMultiplierUpgrade.interactable = false;
        }
        if (coins < currentRockSteadyCost)
        {
            buttonRockSteadyUpgrade.interactable = false;
        }
        if (coins < currentAttackCost)
        {
            buttonAttackUpgrade.interactable = false;
        }
        if (coins < currentSpellCost)
        {
            buttonSpellUpgrade.interactable = false;
        }
        textSpeedLevel.text = "Level: " + currentSpeedLevel.ToString() + "/" + maxSpeedUpgrade.ToString();
        textSpeedCost.text = "$" + currentSpeedCost.ToString();
        textAttackLevel.text = "Level: " + currentAttackLevel.ToString();
        textAttackCost.text = "$" + currentAttackCost.ToString();
        textRockSteadyLevel.text = "Level: " + currentRockSteadyLevel.ToString() + "/" + maxRockSteadyUpgrade.ToString();
        textRockSteadyCost.text = "$" + currentRockSteadyCost.ToString();
        textMultiplierLevel.text = "Level: " + currentMultiplierLevel.ToString() + "/" + maxMultiplierUpgrade.ToString();
        textMultiplierCost.text = "$" + currentMultiplierCost.ToString();
        textSpellLevel.text = "Level: " + currentSpellLevel.ToString();
        textSpellCost.text = "$" + currentSpellCost.ToString();
        textJumpLevel.text = "Level: " + currentJumpLevel.ToString() + "/" + maxJumpUpgrade.ToString();
        textJumpCost.text = "$" + currentJumpCost.ToString();
    }
}
