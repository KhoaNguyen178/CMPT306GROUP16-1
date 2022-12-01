using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Fireball;
    public GameObject TrapBullet;
    public Animator Anime;

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && !Input.GetButtonDown("Fire2") && !Anime.GetBool("Attacking"))
        {
            Invoke("ShootFireball", 0.4f);
            Invoke("ShootFireball", 0.8f);
        }
        if (Input.GetButtonDown("Fire2") && !Input.GetButtonDown("Fire1") && !Anime.GetBool("Attacking"))
        {
            Invoke("ShootTrapBullet", 0.4f);
            Invoke("ShootTrapBullet", 0.8f);
        }
    }

    void ShootTrapBullet()
    {
        int n = GameObject.Find("Player").GetComponent<PlayerController>().GetBulletNumber();
        for (int i = 0; i < 2*n; i++)
        {
            Instantiate(TrapBullet, transform.position, transform.rotation);
        }
    }

    void ShootFireball()
    {
        int n = GameObject.Find("Player").GetComponent<PlayerController>().GetBulletNumber();
        if (n == 1)
        {
            Instantiate(Fireball, transform.position, transform.rotation);
        }
        if (n == 2)
        {
            Vector2 v1 = new Vector2(transform.position.x, (float)(transform.position.y + 0.4));
            Vector2 v2 = new Vector2(transform.position.x, (float)(transform.position.y - 0.4));
            Instantiate(Fireball, v1, transform.rotation);
            Instantiate(Fireball, v2, transform.rotation);
        }
        if (n >= 3)
        {
            Vector2 v1 = new Vector2(transform.position.x, (float)(transform.position.y + 0.8));
            Vector2 v2 = new Vector2(transform.position.x, (float)(transform.position.y - 0.8));
            Instantiate(Fireball, transform.position, transform.rotation);
            Instantiate(Fireball, v1, transform.rotation);
            Instantiate(Fireball, v2, transform.rotation);
        }
    }
}
