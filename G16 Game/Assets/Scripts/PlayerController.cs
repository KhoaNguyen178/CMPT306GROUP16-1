using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioSource JumpAudio;
    public AudioSource InjuredAudio;
    public AudioSource DieAudio;

    public float face = 1;
    public float PlayerHP = 100f;
    public bool onHurt;

    public float xOffset;
    public float yOffset;
    public RectTransform recTransform;

    public GameObject coinMagnet;

    private void Start()
    {
        Anime.SetBool("Alive", true);
        Anime.SetBool("onHurt", false);
    }
    void Update()
    {
        if (Anime.GetBool("Alive") && !onHurt)
        {
            SwitchAnime();
            Movement();
            coinMagnet.transform.position = new Vector2(transform.position.x, transform.position.y);
        }

        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
        recTransform.position = player2DPosition + new Vector2(xOffset, yOffset);

        if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
        {
            recTransform.gameObject.SetActive(false);
        }
        else
        {
            recTransform.gameObject.SetActive(true);
        }
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0) //Allow the player move leftward or rightward.
        {
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        }
        Anime.SetFloat("speed", Mathf.Abs(facedirection));

        if (facedirection != 0 && face != facedirection)
        {
            face = (face == 1) ? -1 : 1;
            transform.Rotate(0f, 180f, 0f);
        }

        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Groud);  //Check if the player is standing on the ground.
        if (isGround)
        {
            Anime.SetBool("isGround", true);
            jumpTimesLeft = extraJumpTimes; //Reset jumping status when player on the ground.
        }
        if (Input.GetButtonDown("Jump") && jumpTimesLeft > 0) //Allow the player jump.
        {
            Anime.SetBool("isGround", false);
            JumpAudio.Play();
            rb.velocity = Vector2.up * Jumpforce;
            jumpTimesLeft--;
            Anime.SetBool("jumping", true);
        }

    }

    public void PlayerTakeDamage(float damage) // Player gets hurted and check if dies.
    {
        PlayerHP -= damage;
        HealthSystem.Instance.TakeDamage(damage);
        if (PlayerHP <= 0)
        {
            DieAudio.Play();
            Anime.SetBool("Alive", false);
            Anime.SetTrigger("Die");
            Die(); // Tam added this line
        }
        else
        {
            InjuredAudio.Play();
            onHurt = true;
            Anime.SetBool("onHurt", true);
            Anime.SetBool("isGround", false);
            Invoke("HurtedCancel", 0.5f);
        }
    }

    public void HurtedCancel()
    {
        onHurt = false;
        Anime.SetBool("onHurt", false);
    }


    void AccordingDirectionFlip(Collision2D collision)
    {
        if (collision != null)
        {
            int direction;
            if (collision.transform.position.x < transform.position.x)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            if (direction != face)
            {
                face = (face == 1) ? -1 : 1;
                transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            GameManager.instance.AddCoins(3);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Silver")
        {
            GameManager.instance.AddCoins(1);
            Destroy(collision.gameObject);
        }

    }

    void Hurt(Collision2D collision)
    {
        if (Anime.GetBool("Alive"))
        {
            PlayerTakeDamage(collision.gameObject.GetComponent<EnemyAttribute>().damageToPlayer);
        }
        AccordingDirectionFlip(collision);
        rb.velocity = Vector2.up * 7f;
        rb.velocity = new Vector2(face * -7, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hurt(collision);
            //Prevent enemy from being pushed by player
            var temp = collision.gameObject.GetComponent<Rigidbody2D>();
            temp.constraints = RigidbodyConstraints2D.FreezeAll;
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
                Anime.SetBool("isGround", true);
            }
        }
    }

    void Die() //Tam added this line
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
