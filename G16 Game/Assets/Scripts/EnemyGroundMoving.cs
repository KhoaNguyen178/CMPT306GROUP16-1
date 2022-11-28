using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundMoving : MonoBehaviour
{

    // Start is called before the first frame update
    //public Transform[] checkpoint;
    public float moveSpeed;
    public int patrolDestination;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    public Transform groundDetection;
    private bool movingRight = true;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D groundInfor = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

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


        if (isChasing && groundInfor.collider == true)
        {
            if (transform.position.x < playerTransform.position.x)
            {
                transform.eulerAngles = new Vector3(0, -0, 0);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                //patrolDestination = 1;
            }

            if (transform.position.x > playerTransform.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                //patrolDestination = 0;
            }
        }

       
  
            if (groundInfor.collider == false)
            {
                if (!isChasing)
                {
                    if (movingRight == true)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingRight = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                    }
                }
            
            }
    }
}