using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 previousPosition;
    bool platformBack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousPosition = transform.position;
    }

    void Update()
    {
        if (platformBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, previousPosition, 20f * Time.deltaTime);
        }

        if(transform.position.y == previousPosition.y)
        {
            platformBack = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !platformBack)
        {
            Invoke("DropPlatform", 1f);
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
        platformBack = true;
    }
}
