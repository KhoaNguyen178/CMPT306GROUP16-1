using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10.0f;
    public Animator Anime;

    public LayerMask Groud;
    public float Jumpforce = 12.5f;
    public Transform GroundCheck;
    public bool isGround;
    public int extraJumpTimes = 1;
    public int jumpTimesLeft;

    void Update()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Groud);  //Check if the player is standing on the ground.
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


        if (isGround)
        {
            jumpTimesLeft = extraJumpTimes; //Reset jumping status when player on the ground.
        }
        if (Input.GetButtonDown("Jump") && jumpTimesLeft > 0) //Allow the player jump.
        {
            rb.velocity = Vector2.up * Jumpforce;
            jumpTimesLeft--;
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
            if (isGround)
            {
                Anime.SetBool("falling", false);
                Anime.SetBool("idle", true);
            }
        }
    }
}
