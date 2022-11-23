using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] ground;
    bool hasGround = true;
    bool isSpawned = true;
  


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
        
        if (randomNum == 0)
        {
            Instantiate(ground[0], new Vector3(transform.position.x + 14, -4.5498f, 0), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(transform.position.x + 14, -4.5498f, 0), transform.rotation);
            isSpawned = true;
        }

        if (randomNum == 1)
        {
            Instantiate(ground[1], new Vector3(transform.position.x + 8, -2.52f, 0), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(transform.position.x + 8, -2.52f, 0), transform.rotation);
            isSpawned = true;
        }

        if (randomNum == 2)
        {
            Instantiate(ground[2], new Vector3(transform.position.x + 4, -2.58f, 0), Quaternion.identity);
            //Instantiate(enemyPrefab, new Vector3(transform.position.x + 4, -2.58f, 0), transform.rotation);
            isSpawned = true;
        }

        if (randomNum == 3)
        {
            Instantiate(ground[3], new Vector3(transform.position.x + 5, -2.56f, 0), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(transform.position.x + 5, -2.56f, 0), transform.rotation);
            isSpawned = true;
        }

        if (randomNum == 4)
        {
            Instantiate(ground[4], new Vector3(transform.position.x + 9, -2.92f, 0), Quaternion.identity); //11
            Instantiate(enemyPrefab, new Vector3(transform.position.x + 9, -2.92f, 0), transform.rotation);
            isSpawned = true;
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

            Debug.Log("left");
        }

        //if (collision.gameObject.CompareTag("Ground") && horizontalMove > 0)
        //{
        //    hasGround = true;

        //    Debug.Log("right");
        //}

        if (horizontalMove > 0 && GameObject.Find("Ground"))
        {
            hasGround = true;
          
            Debug.Log("right");
        }



        if (horizontalMove > 0 && collision.gameObject.CompareTag("Spawn"))
        {
            hasGround = false;
            Debug.Log("spawn");
        }


    }


}
