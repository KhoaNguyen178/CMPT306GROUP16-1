
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;
    [SerializeField] private float damageToSelf = 10.0f;
    //public Slider slider;
    //public GameObject deathEffect;
    public GameObject silverCoin;
    public GameObject goldCoin;
    //public GameObject HPCanvas;
    public GameObject sprites;

    //Add on
    public int attackDamage = 20;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.time > damageTime) //testing drop
        {
            this.TakeDamage(damageToSelf);
            damageTime = Time.time + damageRate;
        }*/
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        //HPCanvas.SetActive(true);
        DamagePopup.Create(this.transform.position, damage);
        StartCoroutine(FlashRed());

        if (health <= 0)
        {
            Destroy(this.gameObject);
            
            //Instantiate(deathEffect, transform.position, transform.rotation);

            int rando1 = UnityEngine.Random.Range(2, 5);
            float tempVar = 0.0f;
            for (int i = 0; i < rando1; i++)
            {
                int rando2 = UnityEngine.Random.Range(1, 10);
                Vector3 tempV3 = new Vector3(transform.position.x + tempVar, transform.position.y, transform.position.z);
                if (rando2 <= 2)
                {
                    GameObject drop = Instantiate(goldCoin, tempV3, transform.rotation);
                }
                else
                {
                    GameObject drop = Instantiate(silverCoin, tempV3, transform.rotation);
                }
                tempVar += 0.1f;
            }
            GameManager.instance.AddKill();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        /*
        if(collision.transform.tag == "Player" && Time.time > damageTime)
        {
            var temp = this.GetComponent<Rigidbody2D>();
            temp.constraints = RigidbodyConstraints2D.FreezeAll;
            this.TakeDamage(damageToSelf);
            StartCoroutine(FlashRed());
            damageTime = Time.time + damageRate;
        }
        */
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var temp = this.GetComponent<Rigidbody2D>();
        temp.constraints = RigidbodyConstraints2D.None;
    }
    public IEnumerator FlashRed()
    {
        foreach (Transform child in sprites.transform)
        {
            if (child.GetComponent<SpriteRenderer>() != null)
            {
                //Each enemy has a body with more child sprites
                foreach (Transform bodyPart in child)
                {
                    if (bodyPart.GetComponent<SpriteRenderer>() != null)
                    {
                        bodyPart.GetComponent<SpriteRenderer>().material.color = Color.red;
                    }

                }
                child.GetComponent<SpriteRenderer>().material.color = Color.red;
            }
        }

        yield return new WaitForSeconds(0.1f);

        foreach (Transform child in sprites.transform)
        {
            if (child.GetComponent<SpriteRenderer>() != null)
            {
                foreach (Transform bodyPart in child)
                {
                    if (bodyPart.GetComponent<SpriteRenderer>() != null)
                    {
                        bodyPart.GetComponent<SpriteRenderer>().material.color = Color.white;
                    }

                }
                child.GetComponent<SpriteRenderer>().material.color = Color.white;
            }

        }
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            //Instantiate(projectile, transform.position, Quaternion.identity);
            colInfo.GetComponent<PlayerController>().PlayerTakeDamage(attackDamage);

        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

  
}

