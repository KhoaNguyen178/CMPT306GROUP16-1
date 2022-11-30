using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float ProjectileDamge = 20.0f;
    public Rigidbody2D rb;

    PlayerController target;
    Vector2 moveDirect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerController>();
        moveDirect = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirect.x, moveDirect.y);
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit!");
            collision.GetComponent<PlayerController>().PlayerTakeDamage(ProjectileDamge);
            Destroy(this.gameObject);
        }
    }
}
