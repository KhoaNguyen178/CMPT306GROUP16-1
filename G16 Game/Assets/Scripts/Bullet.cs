using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 15.0f;
    public float BulletDamage = 20.0f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;
        Destroy(gameObject, 3); //Destory the bullet after 3 seconds.
    }

    private void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D other)// Whien hit something.
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(BulletDamage);
            Destroy(this.gameObject);
        }
    }

    public GameObject FindClosestEnemy() //Find the nearest enemy object.
    {
        GameObject closest = GameObject.FindWithTag("Enemy");
        if (GameObject.FindGameObjectsWithTag("Enemy") != null)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Enemy");
            var distance = Mathf.Infinity;
            var position = transform.position;
            foreach (GameObject go in gos)
            {
                var diff = (go.transform.position - position);
                var curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }
        return closest;
    }

    private void Movement()
    {
        GameObject target = FindClosestEnemy();
        if (transform.position.y > target.transform.position.y)
        {
            Vector2 v = new Vector2(0, -3);
            rb.AddForce(v);
        }
        else
        {
            if (transform.position.y < target.transform.position.y)
            {
                Vector2 v = new Vector2(0, 3);
                rb.AddForce(v);
            }
        }
    }
}
