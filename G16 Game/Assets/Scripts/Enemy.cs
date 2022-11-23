using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    public float damageToPlayer = 10.0f;
    [SerializeField] private float damageToSelf = 10.0f; //testing
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;
    //public Slider slider;
    //public GameObject deathEffect;
    public GameObject silverCoin;
    public GameObject goldCoin;
    //public GameObject HPCanvas;
    public GameObject sprites;
    public GameObject deathEffect;

    public AudioSource audioTakingDmg;

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
        //slider.value = health;

        //HPCanvas.SetActive(true);
        StartCoroutine(FlashRed());


        if (health <= 0)
        {
            Destroy(this.gameObject);
            GameManager.instance.AddKill();
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 0.35f);
            float rando1 = UnityEngine.Random.Range(1, 10);
            if(rando1 <= 2)
            {
                GameObject drop = Instantiate(goldCoin, transform.position, transform.rotation);
            }
            else
            {
                GameObject drop = Instantiate(silverCoin, transform.position, transform.rotation);
            }

        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && Time.time > damageTime)
        {
            //Prevent enemy from being pushed by player
            var temp = this.GetComponent<Rigidbody2D>();
            temp.constraints = RigidbodyConstraints2D.FreezeAll;
            //We would change this to player attack rather than player tag
            audioTakingDmg.GetComponent<AudioSource>().Play();
            this.TakeDamage(damageToSelf);
            StartCoroutine(FlashRed());
            damageTime = Time.time + damageRate;
        }
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
        //if (other.transform.tag == "Player")
        //{
            //other.GetComponent<PlayerController>().PlayerTakeDamage(damageToPlayer);
            //damageTime = Time.time + damageRate;
        //}
    //}


    private void OnCollisionExit2D(Collision2D other)
    {
        //Unfreeze enemy
        var temp = this.GetComponent<Rigidbody2D>();
        temp.constraints = RigidbodyConstraints2D.None;
    }

    public IEnumerator FlashRed()
    {
        foreach(Transform child in sprites.transform)
        {
            if(child.GetComponent<SpriteRenderer>() != null)
            {
                child.GetComponent<SpriteRenderer>().material.color = Color.red;
            }
        }

        yield return new WaitForSeconds(0.1f);

        foreach (Transform child in sprites.transform)
        {
            if(child.GetComponent<SpriteRenderer>() != null)
            {
                child.GetComponent<SpriteRenderer>().material.color = Color.white;
            }

        }
    }
}
