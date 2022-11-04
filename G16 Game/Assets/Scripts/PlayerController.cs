using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10.0f;
    public float jumpforce = 10.0f;
    public Animator Anime;
    [SerializeField] private float damage = 50.0f;

    void Update()
    {
        SwitchAnime();
        Movement();
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0) //Allow the player move leftward or rightward.
        {
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
            Anime.SetFloat("speed", Mathf.Abs(facedirection));
        }

        if (facedirection != 0) //Change the player's direction.
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }

        if (Input.GetButtonDown("Jump")) //Allow the player jump.
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            Anime.SetBool("jumping", true);
        }

        if (Input.GetButtonDown("Fire1")) //Allow the player attack.(Just a testing animation now)
        {
            if (Anime.GetBool("attack1"))
            {
                Anime.SetBool("attack1", false);
            }
            else
            {
                Anime.SetBool("attack1", true);
            }
        }
    }

    void SwitchAnime()
    {
        if (Anime.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                Anime.SetBool("jumping", false);
                Anime.SetBool("falling", true);
            }
        }

        if (Anime.GetBool("falling"))
        {
            if (rb.velocity.y >= 0)
            {
                Anime.SetBool("falling", false);
                Anime.SetBool("idle", true);
            }
        }
    }

}
