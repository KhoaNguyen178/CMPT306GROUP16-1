using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Animator Anime;

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && !Anime.GetBool("Attacking"))
        {
            Invoke("Shoot", 0.4f);
            //Invoke("Shoot", 0.8f);
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, transform.position, transform.rotation);
    }
}
