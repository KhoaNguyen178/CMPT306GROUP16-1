using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if(this.gameObject.tag == "Gold")
            {
                GameManager.instance.AddCoins(3);
            }
            else
            {
                GameManager.instance.AddCoins(1);
            }
            Destroy(this.gameObject);
        }
    }
}
