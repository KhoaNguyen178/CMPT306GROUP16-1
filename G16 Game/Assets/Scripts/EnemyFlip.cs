using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    public GameObject sprite;

    public void FlipSprite()
    {
        sprite.transform.localScale = new Vector2(sprite.transform.localScale.x * -1, sprite.transform.localScale.y);

    }

    public void FlipThisSprite()
    {
        transform.localScale = new Vector2(sprite.transform.localScale.x * -1, sprite.transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FlipThisSprite();
        }
    }
  
}
