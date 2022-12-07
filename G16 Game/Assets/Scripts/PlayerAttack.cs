using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float intervalTime;
    public float startTime;
    public float AttackDamage = 30.0f;

    public Animator Anime;
    public PolygonCollider2D poly2D;
    public AudioSource AttackAudio1;
    public AudioSource AttackAudio2;

    public GameObject Shooter;
    public GameObject Fireball;
    public GameObject TrapBullet;

    private void Start()
    {
        Shooter = GameObject.Find("Shooter");
        poly2D.enabled = false;
    }
    void Update()
    {
        Attack();
    }

    void PlayAttackAudio()
    {
        AttackAudio2.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)// When hit something.
    {
        if (other.transform.CompareTag("Enemy") && poly2D.enabled)
        {
            other.GetComponent<Enemy>().TakeDamage(AttackDamage);
        }
    }

    void Attack()
    {
        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && !Anime.GetBool("Attacking"))
        {
            Anime.SetBool("Attacking", true);
            Anime.SetTrigger("Attack");
            AttackAudio1.Play();
            StartCoroutine(EnableHitBox());
            Invoke("PlayAttackAudio", 0.55f);
            if (Input.GetButtonDown("Fire1") && !Input.GetButtonDown("Fire2")){
                Invoke("ShootFireball", 0.4f);
                Invoke("ShootFireball", 0.8f);
            }
            if (Input.GetButtonDown("Fire2") && !Input.GetButtonDown("Fire1"))
            {
                Invoke("ShootTrapBullet", 0.4f);
                Invoke("ShootTrapBullet", 0.8f);
            }
        }
    }
    void ShootFireball()
    {
        int n = GameObject.Find("Player").GetComponent<PlayerController>().GetBulletNumber();
        if (n == 1)
        {
            Instantiate(Fireball, Shooter.transform.position, Shooter.transform.rotation);
        }
        if (n == 2)
        {
            Vector2 v1 = new Vector2(Shooter.transform.position.x, (float)(Shooter.transform.position.y + 0.4));
            Vector2 v2 = new Vector2(Shooter.transform.position.x, (float)(Shooter.transform.position.y - 0.4));
            Instantiate(Fireball, v1, Shooter.transform.rotation);
            Instantiate(Fireball, v2, Shooter.transform.rotation);
        }
        if (n >= 3)
        {
            Vector2 v1 = new Vector2(Shooter.transform.position.x, (float)(Shooter.transform.position.y + 0.8));
            Vector2 v2 = new Vector2(Shooter.transform.position.x, (float)(Shooter.transform.position.y - 0.8));
            Instantiate(Fireball, Shooter.transform.position, Shooter.transform.rotation);
            Instantiate(Fireball, v1, Shooter.transform.rotation);
            Instantiate(Fireball, v2, Shooter.transform.rotation);
        }
    }

    void ShootTrapBullet()
    {
        if(this.GetComponentInParent<PlayerController>().PlayerMana >= 10)
        {
            int n = GameObject.Find("Player").GetComponent<PlayerController>().GetBulletNumber();
            for (int i = 0; i < 2 * n; i++)
            {
                Instantiate(TrapBullet, Shooter.transform.position, Shooter.transform.rotation);
            
            }
            this.GetComponentInParent<PlayerController>().spendMana(10);
        }
    }

    IEnumerator EnableHitBox() //Start to make damage.
    {
        yield return new WaitForSeconds(startTime);
        poly2D.enabled = true;
        StartCoroutine(DisableHitBox());
    }
    IEnumerator DisableHitBox() //Stop to make damage.
    {
        yield return new WaitForSeconds(intervalTime);
        poly2D.enabled = false;
        Anime.SetBool("Attacking", false);
    }
}
