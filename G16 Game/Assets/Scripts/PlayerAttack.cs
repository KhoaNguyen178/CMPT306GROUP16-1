using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float intervalTime;
    public float startTime;

    public Animator Anime;
    public PolygonCollider2D poly2D;
    public AudioSource AttackAudio;

    void Update()
    {
        Attack();
    }

    void PlayAttackAudio()
    {
        AttackAudio.Play();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && !Anime.GetBool("Attacking"))
        {
            Anime.SetBool("Attacking", true);
            PlayAttackAudio();
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
