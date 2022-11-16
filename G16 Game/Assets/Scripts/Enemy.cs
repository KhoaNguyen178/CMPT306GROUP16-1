using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float damageToSelf = 10.0f; //testing
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;
    //public Slider slider;
    //public GameObject deathEffect;
    public GameObject silverCoin;
    public GameObject goldCoin;
    public GameObject HPCanvas;
    public GameObject sprite;

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
        HPCanvas.SetActive(true);

        if (health <= 0)
        {
            Destroy(this.gameObject);
            //Instantiate(deathEffect, transform.position, transform.rotation);
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
            //We would change this to player attack rather than player tag
            this.TakeDamage(damageToSelf);
            StartCoroutine(FlashRed());
            damageTime = Time.time + damageRate;
        }
    }

    public IEnumerator FlashRed()
    {
        //sprite.color = Color.red;
        sprite.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = Color.red;
        sprite.transform.GetChild(1).GetComponent<SpriteRenderer>().material.color = Color.red;
        sprite.transform.GetChild(2).GetComponent<SpriteRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = Color.white;
        sprite.transform.GetChild(1).GetComponent<SpriteRenderer>().material.color = Color.white;
        sprite.transform.GetChild(2).GetComponent<SpriteRenderer>().material.color = Color.white;
        //sprite.color = Color.white;
    }
}
