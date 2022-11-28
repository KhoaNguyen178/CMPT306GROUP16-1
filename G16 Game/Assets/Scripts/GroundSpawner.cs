using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject[] ground;
    public GameObject[] enemy;

    bool hasGround = true;

  


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGround)
        {
            SpawnGround();
            hasGround = true;
        }
    }
 

    public void SpawnGround()
    {
       
        int randomNum = Random.Range(0, ground.Length);
        int randomEnemy = Random.Range(0, enemy.Length);
        
        if (randomNum == 0)
        {
            Instantiate(ground[0], new Vector3(transform.position.x + 14, -4.5498f, 0), Quaternion.identity);
            Instantiate(enemy[randomEnemy], new Vector3(transform.position.x + 14, -4.023341f, 0), Quaternion.identity);
            Instantiate(enemy[randomEnemy], new Vector3(transform.position.x + 8, -4.023341f, 0), Quaternion.identity);
            Instantiate(enemy[randomEnemy], new Vector3(transform.position.x + 6, -4.023341f, 0), Quaternion.identity);

        }

        if (randomNum == 1)
        {
            Instantiate(ground[1], new Vector3(transform.position.x + 8, -2.52f, 0), Quaternion.identity);
            Instantiate(enemy[randomEnemy],  new Vector3(transform.position.x + 8, -1.94f, 0), Quaternion.identity);
     
        }

        if (randomNum == 2)
        {
            Instantiate(ground[2], new Vector3(transform.position.x + 4, -2.58f, 0), Quaternion.identity);

        }

        if (randomNum == 3)
        {
            Instantiate(ground[3], new Vector3(transform.position.x + 5, -2.56f, 0), Quaternion.identity);
            Instantiate(enemy[randomEnemy],  new Vector3(transform.position.x + 5, -1.99f, 0), Quaternion.identity); //-1.83
            Instantiate(enemy[randomEnemy],  new Vector3(transform.position.x + 1, -1.13f, 0), Quaternion.identity);

        }

        if (randomNum == 4)
        {
            Instantiate(ground[4], new Vector3(transform.position.x + 9, -2.92f, 0), Quaternion.identity); //11
            Instantiate(enemy[4], new Vector3(transform.position.x + 9, -2.72f, 0), Quaternion.identity);
     
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        float horizontalMove = Input.GetAxis("Horizontal");

        //if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MoveGround"))
        //{
        //    hasGround = true;
        //    isSpawned = true;
        //    Debug.Log("has ground");
        //}
        
        if(GameObject.Find("Ground") && horizontalMove != 0)
        {
            hasGround = true;
            Debug.Log("has ground in right");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        
        if (collision.gameObject.CompareTag("Ground") && horizontalMove < 0)
        {
            hasGround = true;
        }

        //if (collision.gameObject.CompareTag("Ground") && horizontalMove > 0)
        //{
        //    hasGround = true;

        //    Debug.Log("right");
        //}

        if (horizontalMove > 0 && GameObject.Find("Ground"))
        {
            hasGround = true;
        }



        if (horizontalMove > 0 && collision.gameObject.CompareTag("Spawn"))
        {
            hasGround = false;
        }


    }


}
