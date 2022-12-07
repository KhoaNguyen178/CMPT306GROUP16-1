using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onSpeedUpgradeClick()
    {
        if (GameManager.instance.spendOnSpeed())
        {
            player.GetComponent<PlayerController>().upgradePlayerSpeed(0.2f);
        }
    }
    public void onAttackUpgradeClick()
    {
        GameManager.instance.spendCoins(GameManager.instance.currentAttackCost);
        //currentAttackCost = ((int)(currentAttackCost * 2.5));
    }
    public void onJumpUpgradeClick()
    {
        GameManager.instance.spendCoins(GameManager.instance.currentJumpCost);
        //currentJumpCost = ((int)(currentJumpCost * 2.5));
    }
    public void onSpellUpgradeClick()
    {
        GameManager.instance.spendCoins(GameManager.instance.currentSpellCost);
        //currentSpellCost = ((int)(currentSpellCost * 2.5));
    }
    public void onMultiplierUpgradeClick()
    {
        GameManager.instance.spendCoins(GameManager.instance.currentMultiplierCost);
        //currentMultiplierCost = ((int)(currentMultiplierCost * 2.5));
    }

    public void onRockSteadyUpgradeClick()
    {
        if (GameManager.instance.isRockSteady())
        {
            GameManager.instance.spendCoins(GameManager.instance.currentRockSteadyCost);
        }
    }
}

