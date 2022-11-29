using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 20.0f;
    public float BulletDamage = 20.0f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;
        Destroy(gameObject, 5); //Destory the bullet after 5 seconds.
    }

    private void OnTriggerEnter2D(Collider2D other)// Whien hit something.
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(BulletDamage);
            Destroy(this.gameObject);
        }
    }
}
