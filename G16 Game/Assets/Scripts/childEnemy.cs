using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childEnemy : MonoBehaviour
{
    private bool movement;
    private Transform target;
    private Rigidbody2D rb;
    [SerializeField] private GameObject coin;
    [SerializeField] private float damageValue;
    [SerializeField] private GameObject enemySprite;
    [SerializeField] private float yourCurLocalScaleX;

    private float health;
    private Vector3 localScale;

    void Start()
    {
        health = 100.0f;
        target = GameObject.FindWithTag("Player").transform;
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        localScale = transform.localScale;
    }

    void Update()
    {
        if (movement == true && !target.Equals(null))
        {
            Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Random.Range(0, 0.5f) * Time.deltaTime);
        }

        if (target.position.x > transform.position.x)
        {
            localScale.x = -yourCurLocalScaleX;
            transform.localScale = localScale;
        }
        else
        {
            localScale.x = yourCurLocalScaleX;
            transform.localScale = localScale;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            //Destroy(this.gameObject.GetComponent<Rigidbody2D>());
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            movement = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            rb.constraints = RigidbodyConstraints2D.None;
            movement = false;
            if (transform.position.y < -5.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            GameManager.instance.AddKill();
            Instantiate(coin, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            this.TakeDamage(damageValue);
            StartCoroutine(FlashingRed());
        }
    }

    private IEnumerator FlashingRed()
    {
        foreach (Transform child in enemySprite.transform)
        {
            if (child.GetComponent<SpriteRenderer>() != null)
            {
                child.GetComponent<SpriteRenderer>().material.color = Color.red;
            }
        }

        yield return new WaitForSeconds(0.1f);

        foreach (Transform child in enemySprite.transform)
        {
            if (child.GetComponent<SpriteRenderer>() != null)
            {
                child.GetComponent<SpriteRenderer>().material.color = Color.white;
            }
        }
    }
}