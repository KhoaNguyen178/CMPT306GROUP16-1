using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject[] ground;
    public GameObject[] groundEnemy;
    public GameObject[] flyEnemy;
    public GameObject[] reward;

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
        int randomEnemy = Random.Range(0, groundEnemy.Length);
        //int randomFlyEnemy = Random.Range(0, flyEnemy.Length);
        int randomReward = Random.Range(0, reward.Length);

        if (randomNum == 0)
        {
            Instantiate(ground[0], new Vector3(transform.position.x + 13, -4.5498f, 0), Quaternion.identity); //-3.066727


            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 8, 0, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 15, 1, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 11, 2, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 19, 3, 0), Quaternion.identity);

            Instantiate(reward[randomReward], new Vector3(transform.position.x + 8, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 10, -2, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 17, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 16, -2, 0), Quaternion.identity);


        }

        if (randomNum == 1)
        {
            Instantiate(ground[1], new Vector3(transform.position.x + 8, -2.52f, 0), Quaternion.identity); //-1.68

            Instantiate(groundEnemy[randomEnemy], new Vector3(transform.position.x + 8, -1.94f, 0), Quaternion.identity);


            Instantiate(reward[randomReward], new Vector3(transform.position.x + 8, 0, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 10, 0, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 17, -1, 0), Quaternion.identity);


        }

        if (randomNum == 2)
        {
            Instantiate(ground[2], new Vector3(transform.position.x + 3, -2.58f, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 3, 1, 0), Quaternion.identity);

        }

        if (randomNum == 3)
        {
            Instantiate(ground[3], new Vector3(transform.position.x + 7, -2.56f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 15, 8f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 20, 9f, 0), Quaternion.identity);

            Instantiate(reward[randomReward], new Vector3(transform.position.x + 8, 0, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 10, 1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 17, 0, 0), Quaternion.identity);


        }

        if (randomNum == 4)
        {
            Instantiate(ground[4], new Vector3(transform.position.x + 8, -2.92f, 0), Quaternion.identity); //11
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 8, -2, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 12, -2, 0), Quaternion.identity);
        }

        if (randomNum == 5)
        {
            Instantiate(ground[5], new Vector3(transform.position.x + 20, -4.548f, 0), Quaternion.identity); //11
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 21, 8f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 29, 9f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 24, 10f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 25, 7f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 30, 10f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 10, 7f, 0), Quaternion.identity);


            //Instantiate(flyEnemy[2], new Vector3(transform.position.x + 21, 3f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[2], new Vector3(transform.position.x + 19, 4f, 0), Quaternion.identity);

            Instantiate(groundEnemy[randomEnemy], new Vector3(transform.position.x + 20, -3.97611f, 0), Quaternion.identity);

            Instantiate(reward[randomReward], new Vector3(transform.position.x + 25, -2, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 29, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 24, -2, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 27, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 30, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 27, -1, 0), Quaternion.identity);

        }

        if (randomNum == 6)
        {
            Instantiate(ground[6], new Vector3(transform.position.x + 18, -4.560649f, 0), Quaternion.identity); //11
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 21, 13f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 25, 8f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[1], new Vector3(transform.position.x + 18, 6f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[2], new Vector3(transform.position.x + 17, 7f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[3], new Vector3(transform.position.x + 24, 7f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[3], new Vector3(transform.position.x + 29, 9f, 0), Quaternion.identity); 
          
            
            Instantiate(groundEnemy[randomEnemy], new Vector3(transform.position.x + 25, -3.85f, 0), Quaternion.identity);
            


            Instantiate(reward[randomReward], new Vector3(transform.position.x + 25, 1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 29, 2, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 24, 1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 27, 1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 30, 1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 17, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 15, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 19, -2, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 10, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 12, -2, 0), Quaternion.identity);
        }
        
        if (randomNum == 7)
        {
            Instantiate(ground[7], new Vector3(transform.position.x + 17, -4.39f, 0), Quaternion.identity); //11
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 21, -1f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 21, -1f, 0), Quaternion.identity);
 
            //Instantiate(flyEnemy[2], new Vector3(transform.position.x + 19, 4f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[3], new Vector3(transform.position.x + 25, 3f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 23, 3f, 0), Quaternion.identity);
            
 
            Instantiate(groundEnemy[randomEnemy], new Vector3(transform.position.x + 18, -3.85f, 0), Quaternion.identity);
           
                


            Instantiate(reward[randomReward], new Vector3(transform.position.x + 25, 1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 29, -2, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 24, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 27, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 30, 1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 27, -2, 0), Quaternion.identity);
        }

        if (randomNum == 8)
        {
            Instantiate(ground[8], new Vector3(transform.position.x + 14, -3.279542f, 0), Quaternion.identity); //11
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 21, -1f, 0), Quaternion.identity);
       
            Instantiate(groundEnemy[randomEnemy], new Vector3(transform.position.x + 18, -3.97611f, 0), Quaternion.identity);

                
         
  
             //Instantiate(flyEnemy[1], new Vector3(transform.position.x + 17, 4f, 0), Quaternion.identity);
             //Instantiate(flyEnemy[2], new Vector3(transform.position.x + 16, 3.5f, 0), Quaternion.identity);
             //Instantiate(flyEnemy[2], new Vector3(transform.position.x + 12, 2f, 0), Quaternion.identity);

            Instantiate(reward[randomReward], new Vector3(transform.position.x + 25, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 29, -1, 0), Quaternion.identity);
            Instantiate(reward[1], new Vector3(transform.position.x + 24, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 27, -1, 0), Quaternion.identity);
            Instantiate(reward[0], new Vector3(transform.position.x + 30, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 27, -1, 0), Quaternion.identity);

        }

        if (randomNum == 9)
        {
            Instantiate(ground[9], new Vector3(transform.position.x + 19, 7.74f, 0), Quaternion.identity);

            Instantiate(groundEnemy[randomEnemy], new Vector3(transform.position.x + 21, -4.007451f, 0), Quaternion.identity);

            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 21, 10f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[1], new Vector3(transform.position.x + 27, 11f, 0), Quaternion.identity);


            //Instantiate(flyEnemy[2], new Vector3(transform.position.x + 17, 11.9f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 17, 13f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 12, 14f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 9, 13.4f, 0), Quaternion.identity);


            //Instantiate(flyEnemy[2], new Vector3(transform.position.x + 34, 15f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[4], new Vector3(transform.position.x + 38, 15f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[3], new Vector3(transform.position.x + 42, 14f, 0), Quaternion.identity);
            //Instantiate(flyEnemy[4], new Vector3(transform.position.x + 50, 12f, 0), Quaternion.identity);

            Instantiate(reward[randomReward], new Vector3(transform.position.x + 25, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 29, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 24, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 36, 1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 30, -1, 0), Quaternion.identity);
            Instantiate(reward[randomReward], new Vector3(transform.position.x + 27, -1, 0), Quaternion.identity);
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
