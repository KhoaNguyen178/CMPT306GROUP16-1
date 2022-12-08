using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject Fireball;
    public float LongestCD = 5f;
    private float Times;
    private GameObject player;
    private GameObject pos;
    private float face = 1;
    // Start is called before the first frame update
    void Start()
    {
        pos = GameObject.Find("FireballShooterPos");
        player = GameObject.Find("Player");
        Times = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Times += Time.deltaTime;
        if (Times >= LongestCD)
        {
            ShootFireball();
            Times -= Random.value * LongestCD;
        }

        Movement();
    }

    void ShootFireball()
    {
        int n = player.GetComponent<PlayerController>().GetBulletNumber();
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

    void Movement()
    {

        transform.position = Vector2.MoveTowards(transform.position, pos.transform.position, 5f * Time.deltaTime);
        if (player.transform.position.x - transform.position.x > 0 && face != 1)
        {
            face = 1;
            transform.Rotate(0f, 180f, 0f);
        }
        if (player.transform.position.x - transform.position.x < 0 && face != -1)
        {
            face = -1;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
