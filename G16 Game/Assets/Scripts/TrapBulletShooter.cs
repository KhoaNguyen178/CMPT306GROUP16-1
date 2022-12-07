using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBulletShooter : MonoBehaviour
{
    public GameObject TrapBullet;
    public float CD = 3f;
    private float Times;
    private GameObject player;
    private GameObject pos;
    private float face = 1;
    // Start is called before the first frame update
    void Start()
    {
        pos = GameObject.Find("TrapBulletShooterPos");
        player = GameObject.Find("Player");
        Times = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Times += Time.deltaTime;
        if (Times >= CD)
        {
            ShootTrapBullet();
            Times -= CD;
        }

        Movement();
    }

    void ShootTrapBullet()
    {
        int n = player.GetComponent<PlayerController>().GetBulletNumber();
        for (int i = 0; i < 2 * n; i++)
        {
            Instantiate(TrapBullet, transform.position, transform.rotation);
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
