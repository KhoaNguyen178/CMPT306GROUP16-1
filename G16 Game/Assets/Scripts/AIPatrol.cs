using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
<<<<<<< Updated upstream
    public Rigidbody2D rb;
    public float walkSpeed;
    private float dirX;
    private Vector2 localScale;

    public Collider2D bodyCollider;
    public LayerMask groundLayer;
    public bool flipFromRight = false;
    public DetectPlayerInArea detectSC;
    private Transform target;

    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = 1.0f;
        target = GameObject.FindWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "collisionRight")
        {
            dirX = -1f;
        }
        else if (collision.gameObject.name == "collisionLeft")
        {
            dirX = 1f;
        }
    }


    void Update()
    {
        if (detectSC.playerDetected == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, walkSpeed * Time.deltaTime);
            if(target.position.x > transform.position.x) // player on right side
            {
                if (localScale.x < 0) { transform.localScale = localScale; } // enemy face to right side, then staying at their right direction
                else if(localScale.x > 0) { localScale.x = -1.0f; } //enemy face to left side, then they must face to right side
            }
            else if(target.position.x < transform.position.x) // player on left side
            {
                if(localScale.x < 0) { localScale.x = 1.0f; } // enemy face to right side, then they must face to left side
                else if(localScale.x > 0) { transform.localScale = localScale; } //enemy face to left side, then staying at their left direction
            }
            
            transform.localScale = localScale;
        }
        else if (detectSC.playerDetected == false)
        {
            rb.velocity = new Vector2(dirX * walkSpeed, rb.velocity.y);
            CheckFlip();
        }
    }

    void CheckFlip()
    {
        if (dirX > 0)
        {
            flipFromRight = false;
        }
        else if (dirX < 0)
        {
            flipFromRight = true;
        }
        if ((flipFromRight && (localScale.x < 0)) || (!flipFromRight && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
=======
    public float walkSpeed;

    [HideInInspector] public bool mustPatrol;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundlayer;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }


    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
>>>>>>> Stashed changes
    }
}
