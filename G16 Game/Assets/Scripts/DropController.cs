using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Vector2 playerDirection;
    float timeStamp;
    bool flyToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flyToPlayer)
        {
            playerDirection = -(transform.position - player.transform.position).normalized;
            rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * 10f * (Time.time / timeStamp);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       /* if (other.transform.tag == "Player")
        {
            if(this.gameObject.tag == "Gold")
            {
                GameManager.instance.AddCoins(3);
                Destroy(this.gameObject);
            }
            else if (this.gameObject.tag == "Silver")
            {
                GameManager.instance.AddCoins(1);
                Destroy(this.gameObject);
            }
        }*/
       if(other.gameObject.name.Equals("CoinMagnet"))
        {
            timeStamp = Time.time;
            player = GameObject.Find("Player");
            flyToPlayer = true;
        }
    }
}
