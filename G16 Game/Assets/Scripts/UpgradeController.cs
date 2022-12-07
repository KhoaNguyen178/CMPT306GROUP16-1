using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public GameObject player;

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
    private int currentSpeedCost;
    private int currentAttackCost;
    private int currentJumpCost;
    private int currentSpellCost;
    private int currentMultiplierCost;
    private int currentRockSteadyCost;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetCost()
    {
        currentSpeedCost = 5;
        currentAttackCost = 5;
        currentJumpCost = 5;
        currentSpellCost = 10;
        currentMultiplierCost = 20;
        currentRockSteadyCost = 500;
    }

    public void onSpeedUpgradeClick()
    {
        player.GetComponent<PlayerController>().upgradePlayerSpeed(0.2f);
        GameManager.instance.spendCoins(currentSpeedCost);
        currentSpeedCost = ((int)(currentSpeedCost * 2.5));
    }
    public void onAttackUpgradeClick()
    {
        GameManager.instance.spendCoins(currentAttackCost);
        currentAttackCost = ((int)(currentAttackCost * 2.5));
    }
    public void onJumpUpgradeClick()
    {
        GameManager.instance.spendCoins(currentJumpCost);
        currentJumpCost = ((int)(currentJumpCost * 2.5));
    }
    public void onSpellUpgradeClick()
    {
        GameManager.instance.spendCoins(currentSpellCost);
        currentSpellCost = ((int)(currentSpellCost * 2.5));
    }
    public void onMultiplierUpgradeClick()
    {
        GameManager.instance.spendCoins(currentMultiplierCost);
        currentMultiplierCost = ((int)(currentMultiplierCost * 2.5));
    }
    
    public void onRockSteadyUpgradeClick()
    {
        if(currentRockSteadyLevel < maxRockSteadyUpgrade)
        {
            GameManager.instance.spendCoins(currentRockSteadyCost);
        }
    }

}

