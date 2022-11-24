using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onUpgrade1Click()
    {
        GameManager.instance.spendCoins(3);
    }
    public void onUpgrade2Click()
    {
        GameManager.instance.spendCoins(3);
    }
    public void onUpgrade3Click()
    {
        GameManager.instance.spendCoins(3);
    }
}

