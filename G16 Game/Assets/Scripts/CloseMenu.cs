using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
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
    public void onCloseClick()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.resetProgress();
    }
}
