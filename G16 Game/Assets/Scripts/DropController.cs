using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    private HealthSystem healthSystem_SC;
    void Start()
    {
        healthSystem_SC = GameObject.Find("TinyHealthSystem").GetComponent<HealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if(this.gameObject.tag == "Gold")
            {
                GameManager.instance.AddCoins(3);
            }
            else if(this.gameObject.tag == "Silver")
            {
                GameManager.instance.AddCoins(1);
            }
            else
            {
                healthSystem_SC.HealDamage(30);
            }
            Destroy(this.gameObject);

        }
    }
}
