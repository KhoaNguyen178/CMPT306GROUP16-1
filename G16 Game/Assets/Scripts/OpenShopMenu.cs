using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopMenu : MonoBehaviour
{
    public GameObject upgradeMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onOpenClick()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0;
        GameManager.instance.checkButtons();
    }
}
