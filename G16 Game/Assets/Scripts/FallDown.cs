using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 previousPlatform;
    bool platforMovingBack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousPlatform = transform.position;
    }

    void Update()
    {
        if (platforMovingBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, previousPlatform, 20f * Time.deltaTime);
        }
        if(transform.position.y == previousPlatform.y)
        {
            platforMovingBack = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !platforMovingBack)
        {
            Invoke("DropPlatform", 0.5f);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
        Invoke("GetPlatformBack", 1f);
    }

    void GetPlatformBack()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        platforMovingBack = true;
    }
}
