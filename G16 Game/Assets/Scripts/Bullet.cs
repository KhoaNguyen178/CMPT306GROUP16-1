using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 5.0f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;
        Destroy(gameObject, 10); //Destory the bullet after 10 seconds.
    }

    private void OnTriggerEnter2D(Collider2D collision)// Whien hit something.
    {
        if (collision.gameObject.tag == "Enemy") //If hit enemy.
        {
            // Hurting codes go here.
            Destroy(gameObject);
        }
    }
}
