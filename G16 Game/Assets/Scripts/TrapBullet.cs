using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBullet : MonoBehaviour
{
    public float BulletSpeed = 12.0f;
    public float BulletDamage = 20.0f;
    public Rigidbody2D rb;

    void Start()
    {
        Vector2 v = new(Random.value, Random.value);
        rb.velocity = v * BulletSpeed;
        Destroy(gameObject, 1); //Destory the bullet after 1 seconds.
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

        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        this.transform.Translate(new Vector3(10f * Time.deltaTime, 1f * Time.deltaTime, 1f * Time.deltaTime));
    }
}
