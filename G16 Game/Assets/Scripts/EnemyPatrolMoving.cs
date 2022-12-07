using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMoving : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5;
    
    [SerializeField]Transform castPos;
    [SerializeField]float baseCastDistance;

    const string LEFT = "left";
    const string RIGHT = "right";

    string facingDirection;

    Vector3 baseScale;

    public bool isChasing;
    public float chaseDistance;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        {
            isChasing = true;
            Debug.Log(" CHASING");
        }

        if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance)
        {
            isChasing = false;
            Debug.Log("NOT CHASING");
        }


        if (isChasing)
        {
            if (transform.position.x < playerTransform.position.x)
            {
                if (facingDirection == LEFT)
                {
                    EnemyFlip(RIGHT);
                }
            }

            if (transform.position.x > playerTransform.position.x)
            {
                if (facingDirection == RIGHT)
                {
                    EnemyFlip(LEFT);
                }
            }
        }

       
    }

    private void FixedUpdate()
    {
        float vX = moveSpeed;

        if (facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }


        //move the game object
        rb.velocity = new Vector2(vX, rb.velocity.y);


        if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance && IsHittingWall() || IsNearEdge())
        {
            isChasing = false;
        }

        if (IsHittingWall() || IsNearEdge())
        {
            if (facingDirection == LEFT)
            {
                EnemyFlip(RIGHT);
            }
            else if (facingDirection == RIGHT)
            {
                EnemyFlip(LEFT);
            }
        }

        //if (IsHittingWall() || IsNearEdge())
        //{
        //    if (facingDirection == LEFT)
        //    {
        //        EnemyFlip(RIGHT);
        //    }
        //    else if (facingDirection == RIGHT)
        //    {
        //        EnemyFlip(LEFT);
        //    }
        //}



    }

    void EnemyFlip(string newDirection)
    {
        Vector3 newScale = baseScale;
        if(newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else if(newDirection == RIGHT)
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;
        facingDirection = newDirection;
    }

    bool IsHittingWall()
    {
        bool val = false;

        float castDist = baseCastDistance;
        
        //Define cast distance for left and right
        if(facingDirection == LEFT)
        {
            castDist = baseCastDistance;
        }
        else
        {
            castDist = baseCastDistance;
        }

        //determine the target destination based on the cast dist
        Vector3 targetPos = castPos.position;
        targetPos.x += castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.blue);

        if(Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }

    bool IsNearEdge()
    {
        bool val = true;

        float castDist = baseCastDistance;

        //determine the target destination based on the cast dist
        Vector3 targetPos = castPos.position;
        targetPos.y -= castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.red);

        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }

}
