using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    void Start()
    {
        
    }

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
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfor = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        
        if (isChasing)
            {
                if (transform.position.x > playerTransform.position.x)
                {
                    //transform.localScale = new Vector3(-1, 1, 1);
                    transform.position += Vector3.right * speed * Time.deltaTime;
                    //transform.Translate(Vector2.right * speed * Time.deltaTime);
                    movingRight = true;
                    Debug.Log("Chase left");
                }

                if (transform.position.x < playerTransform.position.x)
                {
                    //transform.localScale = new Vector3(1, 1, 1);
                    transform.position += Vector3.left * speed * Time.deltaTime;
                    //transform.Translate(Vector2.left * speed * Time.deltaTime);
                    movingRight = false;
                    Debug.Log("Chase right");
                }
            }

        if(groundInfor.collider == false)
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
