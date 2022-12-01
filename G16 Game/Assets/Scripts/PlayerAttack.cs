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

    private void Start()
    {
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
