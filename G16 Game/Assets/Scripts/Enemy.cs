using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float damageToSelf = 10.0f; //testing
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float damage = 50.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;
    //public Slider slider;
    public GameObject deathEffect;
    public GameObject gem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value = health;
        /*if (Time.time > damageTime) //testing drop
        {
            this.TakeDamage(damageToSelf);
            damageTime = Time.time + damageRate;
        }*/
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            //Instantiate(deathEffect, transform.position, transform.rotation);
            GameObject drop = Instantiate(gem, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && Time.time > damageTime)
        {
            this.TakeDamage(damageToSelf);
            damageTime = Time.time + damageRate;
        }
    }
}
