
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

    public int BulletNumber = 1;

    //Tam Add on
    private Rigidbody2D rigidbody2D;
    private float moveSpeed, dirX, dirY;
    public bool ClimbingAllowed { get; set; }

    private void Start()
    {
        Anime.SetBool("Alive", true);
        Anime.SetBool("onHurt", false);

        //Tam add on
        rigidbody2D = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
    }
    void Update()
    {
        SwitchAnime();
        if (Anime.GetBool("Alive") && !onHurt && !Anime.GetBool("Attacking"))
        {

            Movement();
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

        // Tam add on
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (ClimbingAllowed)
        {
            dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
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

    public int GetBulletNumber()
    {
        return BulletNumber;
    }

    // Tam add on
    private void FixedUpdate()
    {
        if (ClimbingAllowed)
        {
            rigidbody2D.isKinematic = true;
            rigidbody2D.velocity = new Vector2(dirX, dirY);
        }
        else
        {
            rigidbody2D.isKinematic = false;
            rigidbody2D.velocity = new Vector2(dirX, rb.velocity.y);
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class PlayerController : MonoBehaviour
//{
//    public Rigidbody2D rb;
//    public float speed = 10.0f;
//    public Animator Anime;

//    public LayerMask Groud;
//    public float Jumpforce = 12.5f;
//    public Transform GroundCheck;
//    public bool isGround;
//    public int extraJumpTimes = 1;
//    public int jumpTimesLeft;
//    public AudioSource JumpAudio;
//    public AudioSource InjuredAudio;
//    public AudioSource DieAudio;

//    public float face = 1;
//    public float PlayerHP = 100f;
//    public bool onHurt;

//    public float xOffset;
//    public float yOffset;
//    public RectTransform recTransform;
//    public GameObject DeathMenu;

//    private void Start()
//    {
//        Anime.SetBool("Alive", true);
//        Anime.SetBool("onHurt", false);
//        DeathMenu.SetActive(false);
//    }
//    void Update()
//    {
//        if (Anime.GetBool("Alive") && !onHurt)
//        {
//            SwitchAnime();
//            Movement();
//        }

//        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
//        recTransform.position = player2DPosition + new Vector2(xOffset, yOffset);

//        if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
//        {
//            recTransform.gameObject.SetActive(false);
//        }
//        else
//        {
//            recTransform.gameObject.SetActive(true);
//        }


//        //if (transform.position.y < -5.0f) // menu to play again
//        //{
//        //    DeathMenu.SetActive(true);
//        //    Destroy(this.gameObject);
//        //}
//    }

//    void Movement()
//    {
//        float horizontalMove = Input.GetAxis("Horizontal");
//        float facedirection = Input.GetAxisRaw("Horizontal");
//        if (horizontalMove != 0) //Allow the player move leftward or rightward.
//        {
//            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
//        }
//        Anime.SetFloat("speed", Mathf.Abs(facedirection));

//        if (facedirection != 0 && face != facedirection)
//        {
//            face = (face == 1) ? -1 : 1;
//            transform.Rotate(0f, 180f, 0f);
//        }

//        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Groud);  //Check if the player is standing on the ground.
//        if (isGround)
//        {
//            Anime.SetBool("isGround", true);
//            jumpTimesLeft = extraJumpTimes; //Reset jumping status when player on the ground.
//        }
//        if (Input.GetButtonDown("Jump") && jumpTimesLeft > 0) //Allow the player jump.
//        {
//            Anime.SetBool("isGround", false);
//            JumpAudio.Play();
//            rb.velocity = Vector2.up * Jumpforce;
//            jumpTimesLeft--;
//            Anime.SetBool("jumping", true);
//        }
//    }

//    public void PlayerTakeDamage(float damage) // Player gets hurted and check if dies.
//    {
//        PlayerHP -= damage;
//        HealthSystem.Instance.TakeDamage(damage);
//        if (PlayerHP <= 0)
//        {
//            DieAudio.Play();
//            Anime.SetBool("Alive", false);
//            Anime.SetTrigger("Die");
//            Die(); // Tam added this line
//        }
//        else
//        {
//            InjuredAudio.Play();
//            onHurt = true;
//            Anime.SetBool("onHurt", true);
//            Anime.SetBool("isGround", false);
//            Invoke("HurtedCancel", 0.5f);
//        }
//    }

//    public void HurtedCancel()
//    {
//        onHurt = false;
//        Anime.SetBool("onHurt", false);
//    }


//    void AccordingDirectionFlip(Collision2D collision)
//    {
//        if (collision != null)
//        {
//            int direction;
//            if (collision.transform.position.x < transform.position.x)
//            {
//                direction = -1;
//            }
//            else
//            {
//                direction = 1;
//            }
//            if (direction != face)
//            {
//                face = (face == 1) ? -1 : 1;
//                transform.Rotate(0f, 180f, 0f);
//            }
//        }
//    }

//    void Hurt(Collision2D collision)
//    {
//        if (Anime.GetBool("Alive"))
//        {
//            PlayerTakeDamage(collision.gameObject.GetComponent<EnemyAttribute>().damageToPlayer);
//        }
//        AccordingDirectionFlip(collision);
//        rb.velocity = Vector2.up * 7f;
//        rb.velocity = new Vector2(face * -7, rb.velocity.y);
//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Enemy"))
//        {
//            Hurt(collision);
//            //Prevent enemy from being pushed by player
//            var temp = collision.gameObject.GetComponent<Rigidbody2D>();
//            temp.constraints = RigidbodyConstraints2D.FreezeAll;

//        }
//    }

//    void SwitchAnime()
//    {
//        if (Anime.GetBool("jumping"))
//        {
//            if (rb.velocity.y < 0)
//            {
//                Anime.SetBool("jumping", false);
//                Anime.SetBool("falling", true);
//            }
//        }

//        if (Anime.GetBool("falling"))
//        {
//            if (isGround)
//            {
//                Anime.SetBool("falling", false);
//                Anime.SetBool("idle", true);
//                Anime.SetBool("isGround", true);
//            }
//        }
//    }

//    void Die() //Tam added this line
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//    }
//}
