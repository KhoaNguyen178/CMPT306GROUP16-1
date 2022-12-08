using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet; //regular attack
    public GameObject trapBullet; //spell attack

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
            player.GetComponent<PlayerController>().upgradePlayerSpeed(0.5f);
        }
    }
    public void onAttackUpgradeClick()
    {
        if (GameManager.instance.spendOnAttack())
        {
            bullet.GetComponent<Bullet>().upgradeBulletDamage();
        }
    }
    public void onJumpUpgradeClick()
    {
        if (GameManager.instance.spendOnJump())
        {
            player.GetComponent<PlayerController>().upgradeJump(0.5f);
        }
    }
    public void onSpellUpgradeClick()
    {
        if (GameManager.instance.spendOnSpell())
        {
            trapBullet.GetComponent<TrapBullet>().upgradeBulletDamage();
        }
    }
    public void onMultiplierUpgradeClick()
    {
        if (GameManager.instance.spendOnMultiplier())
        {
            player.GetComponent<PlayerController>().upgradeMultiplier();
        }
    }

    public void onRockSteadyUpgradeClick()
    {
        if (GameManager.instance.spendOnRockSteady())
        {
            player.GetComponent<PlayerController>().enableRockSteady();
        }
    }
}

