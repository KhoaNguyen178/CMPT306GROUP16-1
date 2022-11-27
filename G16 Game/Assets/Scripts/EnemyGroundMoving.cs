using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundMoving : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] checkpoint;
    public float moveSpeed;
    public int patrolDestination;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;


    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        {
            isChasing = true;
        }

        if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance)
        {
            isChasing = false;
            Debug.Log("NOT CHASING");
        }

        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                patrolDestination = 1;

            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                patrolDestination = 0;
            }
        }

        if (!isChasing)
        {
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, checkpoint[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, checkpoint[0].position) < .2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, checkpoint[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, checkpoint[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 0;
                }
            }
        }
       


    }
}
