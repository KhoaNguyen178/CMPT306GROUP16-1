using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int value = 10;
    public AudioClip GemAud;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            GameObject cam = GameObject.Find("Main Camera");
            GameManager.instance.AddCoins(value);
            AudioSource.PlayClipAtPoint(GemAud, cam.transform.position);
            Destroy(this.gameObject);
        }
    }
}
