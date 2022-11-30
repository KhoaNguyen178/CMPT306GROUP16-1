using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
<<<<<<< HEAD

    public GameObject[] ground;
    public GameObject[] enemy;
    public GameObject[] flyEnemy;

    bool hasGround = true;

    
=======

    public GameObject[] ground;
    public GameObject[] enemy;

    bool hasGround = true;

  


>>>>>>> Thao
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
<<<<<<< HEAD
        int randomFlyEnemy = Random.Range(0, flyEnemy.Length);
=======
>>>>>>> Thao
        
        if (randomNum == 0)
        {
            Instantiate(ground[0], new Vector3(transform.position.x + 14, -4.5498f, 0), Quaternion.identity);
<<<<<<< HEAD
            Instantiate(enemy[randomEnemy], new Vector3(transform.position.x + 14, -4.023341f, 0), Quaternion.identity);
            Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 8, -2, 0), Quaternion.identity);
            Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 6, -2f, 0), Quaternion.identity);
=======
            Instantiate(enemy[randomEnemy],  new Vector3(transform.position.x + 14, -3.84f, 0), Quaternion.identity);
            Instantiate(enemy[randomEnemy], new Vector3(transform.position.x + 14, -3.84f, 0), Quaternion.identity);
            Instantiate(enemy[randomEnemy], new Vector3(transform.position.x + 14, -3.84f, 0), Quaternion.identity);
>>>>>>> Thao

        }

        if (randomNum == 1)
        {
            Instantiate(ground[1], new Vector3(transform.position.x + 8, -2.52f, 0), Quaternion.identity);
<<<<<<< HEAD
            Instantiate(enemy[randomEnemy],  new Vector3(transform.position.x + 8, -1.91f, 0), Quaternion.identity);
=======
            Instantiate(enemy[randomEnemy],  new Vector3(transform.position.x + 8, -1.69f, 0), Quaternion.identity);
>>>>>>> Thao
     
        }

        if (randomNum == 2)
        {
            Instantiate(ground[2], new Vector3(transform.position.x + 4, -2.58f, 0), Quaternion.identity);

        }

        if (randomNum == 3)
        {
            Instantiate(ground[3], new Vector3(transform.position.x + 5, -2.56f, 0), Quaternion.identity);
<<<<<<< HEAD
            Instantiate(flyEnemy[randomFlyEnemy],  new Vector3(transform.position.x + 5, 0.1f, 0), Quaternion.identity); //-1.83
            Instantiate(flyEnemy[randomFlyEnemy],  new Vector3(transform.position.x + 1, 0.1f, 0), Quaternion.identity);
=======
            Instantiate(enemy[randomEnemy],  new Vector3(transform.position.x + 5, -1.83f, 0), Quaternion.identity); //-1.83
            Instantiate(enemy[randomEnemy], new Vector3(transform.position.x + 5, -1.83f, 0), Quaternion.identity);
>>>>>>> Thao

        }

        if (randomNum == 4)
        {
            Instantiate(ground[4], new Vector3(transform.position.x + 9, -2.92f, 0), Quaternion.identity); //11
<<<<<<< HEAD
     
        }

        if (randomNum == 5)
        {
            Instantiate(ground[5], new Vector3(transform.position.x + 29.5f, 4.083343f, 0), Quaternion.identity); //11
            Instantiate(flyEnemy[randomFlyEnemy], new Vector3(transform.position.x + 21, .083343f, 0), Quaternion.identity);
        }
=======
            Instantiate(enemy[randomEnemy], new Vector3(transform.position.x + 9, -3.66f, 0), Quaternion.identity);
     
        }

        if (randomNum == 5)
        {
            Instantiate(ground[5], new Vector3(transform.position.x + 9, -2.92f, 0), Quaternion.identity); 
        }

        if (randomNum == 6)
        {
            Instantiate(ground[6], new Vector3(transform.position.x + 9, -2.92f, 0), Quaternion.identity); 
        }

>>>>>>> Thao
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        float horizontalMove = Input.GetAxis("Horizontal");
        
        if(GameObject.Find("Ground") && horizontalMove != 0)
        {
            hasGround = true;
            //Debug.Log("has ground in right");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        
        if (collision.gameObject.CompareTag("Ground") && horizontalMove < 0)
        {
            hasGround = true;
<<<<<<< HEAD
=======

            //Debug.Log("left");
>>>>>>> Thao
        }

        if (horizontalMove > 0 && GameObject.Find("Ground"))
        {
            hasGround = true;
<<<<<<< HEAD
=======
          
            //Debug.Log("right");
>>>>>>> Thao
        }

        if (horizontalMove > 0 && collision.gameObject.CompareTag("Spawn"))
        {
            hasGround = false;
<<<<<<< HEAD
=======
            //Debug.Log("spawn");
>>>>>>> Thao
        }


    }


}
