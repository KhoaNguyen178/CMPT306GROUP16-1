using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    /*public Rigidbody2D rb;
    private float dirX;*/
    public float walkSpeed;
    private Vector3 localScale;

    /*public bool flipFromRight = false;*/
    public DetectPlayerInArea detectSC;
    private Transform playerPos;

    [SerializeField] private Transform leftCollison;
    [SerializeField] private Transform rightCollison;

    private Vector3 targetLeft, targetRight, targetCol;

    //[SerializeField] private SpriteRenderer spriteRenderer;
    //[SerializeField] private Sprite[] newSprite;
    [SerializeField] private GameObject[] newSprite;
    [SerializeField] private GameObject enemyasParent;



    int spriteRandomIndex;

    private PlayerHealth playerHealth_SC;
    private PlayerController playerController_SC;

    void Start()
    {
        localScale = transform.localScale;
        /*rb = GetComponent<Rigidbody2D>();
        dirX = 1.0f;*/
        playerPos = GameObject.FindWithTag("Player").transform;
        targetLeft = new Vector3(leftCollison.position.x, transform.position.y, leftCollison.position.z);
        targetRight = new Vector3(rightCollison.position.x, transform.position.y, rightCollison.position.z);

        spriteRandomIndex = Random.Range(0, newSprite.Length);
        GameObject myChar = Instantiate(newSprite[spriteRandomIndex], enemyasParent.transform.position, Quaternion.identity);
        myChar.transform.parent = enemyasParent.transform;

        playerController_SC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerHealth_SC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "collisionRight")
        {
            //dirX = -1f;
            targetCol = targetLeft;
            localScale.x = 1f;
            transform.localScale = localScale;
        }
        else if (collision.gameObject.name == "collisionLeft")
        {
            //dirX = 1f;
            targetCol = targetRight;
            localScale.x = -1f;
            transform.localScale = localScale;
        }
        else if (collision.gameObject.name == "Player")
        {
            playerHealth_SC.TakeDamage(10);
            playerController_SC.PlayerTakeDamage(10);
        }
    }


    void Update()
    {
        if (detectSC.playerDetected == true)
        {
            Vector3 targetPos = new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, walkSpeed * Time.deltaTime);
            if (playerPos.position.x > transform.position.x) // player on right side
            {
                if (localScale.x < 0) { transform.localScale = localScale; } // enemy face to right side, then staying at their right direction
                else if (localScale.x > 0) { localScale.x = -1.0f; } //enemy face to left side, then they must face to right side
            }
            else if (playerPos.position.x < transform.position.x) // player on left side
            {
                if (localScale.x < 0) { localScale.x = 1.0f; } // enemy face to right side, then they must face to left side
                else if (localScale.x > 0) { transform.localScale = localScale; } //enemy face to left side, then staying at their left direction
            }

            transform.localScale = localScale;
        }
        else if (detectSC.playerDetected == false)
        {
            /*rb.velocity = new Vector2(dirX * walkSpeed, rb.velocity.y);
            CheckFlip();*/
            transform.position = Vector2.MoveTowards(transform.position, targetCol, walkSpeed * Time.deltaTime);
            if (localScale.x > 0)
            {
                targetCol = targetLeft;
            }
            else targetCol = targetRight;
        }

    }

    /*void CheckFlip()
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
    }*/
}