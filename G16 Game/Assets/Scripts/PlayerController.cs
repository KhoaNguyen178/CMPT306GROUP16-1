
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10.0f;
    public Animator Anime;

    public LayerMask Groud;
    public float Jumpforce = 10f;
    public Transform GroundCheck;
    public bool isGround;
    public int extraJumpTimes = 1;
    public int jumpTimesLeft;
    public AudioSource JumpAudio;
    public AudioSource InjuredAudio;
    public AudioSource DieAudio;

    public float face = 1;
    public bool onHurt;

    public float xOffset;
    public float yOffset;
    public RectTransform recTransform;

    public int BulletNumber = 1;

    //Tam Add on
    private Rigidbody2D rigidbody2D;
    public float moveSpeed;
    private float dirX, dirY;
    public bool ClimbingAllowed { get; set; }

    private HealthSystem healthSystem_SC;

    public GameObject coinMagnet;
    public GameObject bullet;
    public GameObject trapBullet;

    //Additional variables for upgrades
    float coinMultiplier = 1;
    bool isRockSteady = false;

    //Variables for player UI
    public Image hpBarFillMask;
    public Image manaBarFillMask;
    public Text hpText;
    public Text manaText;
    public float PlayerHP = 100f;
    public float PlayerMana = 100f;
    public float PlayerMaxHP = 100f;
    public float PlayerMaxMana = 100f;

    private void Start()
    {
        Anime.SetBool("Alive", true);
        Anime.SetBool("onHurt", false);

        //Tam add on
        rigidbody2D = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;

        //healthSystem_SC = GameObject.Find("TinyHealthSystem").GetComponent<HealthSystem>();
        resetDefaults();
        SetHP();
        SetMana();
        StartCoroutine(manaRegen());
        
    }
    void Update()
    {
        SwitchAnime();
        if (Anime.GetBool("Alive") && !onHurt && !Anime.GetBool("Attacking"))
        {
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

        // Tam add on
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (ClimbingAllowed)
        {
            dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
            if (Input.GetButtonDown("Vertical"))
            {
                Anime.SetBool("Climbing", true);
            }
        }
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0) //Allow the player move leftward or rightward.
        {
            //rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
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
            Anime.SetBool("Climbing", false);
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
        SetHP();
        //HealthSystem.Instance.TakeDamage(damage);
        if (PlayerHP <= 0)
        {
            DieAudio.Play();
            Anime.SetBool("Alive", false);
            Anime.SetTrigger("Die");
            Invoke("Die", 3f);
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
            if (!isRockSteady)
            {
                AccordingDirectionFlip(collision);
                rb.velocity = Vector2.up * 7f;
                rb.velocity = new Vector2(face * -7, rb.velocity.y);
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            GameManager.instance.AddCoins((int)(3.0f * coinMultiplier));
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Silver")
        {
            GameManager.instance.AddCoins((int)(1.0f * coinMultiplier));
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Potion")
        {
            healthSystem_SC.HealDamage(30);
            Destroy(collision.gameObject);
        }
       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hurt(collision);
            //Prevent enemy from being pushed by player
            //var temp = collision.gameObject.GetComponent<Rigidbody2D>();
            //temp.constraints = RigidbodyConstraints2D.FreezeAll;
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
        if (Anime.GetBool("Alive") && !onHurt && !Anime.GetBool("Attacking"))
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
    void SetHP()
    {
        hpBarFillMask.fillAmount = PlayerHP / PlayerMaxHP;
        hpText.text = PlayerHP + "/" + PlayerMaxHP;
    }

    void SetMana()
    {
        manaBarFillMask.fillAmount = PlayerMana / PlayerMaxMana;
        manaText.text = PlayerMana + "/" + PlayerMaxMana;
    }

    public void spendMana(int i)
    {
        PlayerMana -= i;
        SetMana();
    }
    IEnumerator manaRegen()
    {
        while(true)
        {
            if(PlayerMana < PlayerMaxMana)
            {
                PlayerMana += 1;
                SetMana();
                yield return new WaitForSeconds(0.3f);
            }
            else
            {
                yield return null;
            }

        }
    }

    public void upgradePlayerSpeed(float i)
    {
        moveSpeed += i;
    }

    //Need to pull player to adjust this upgrade - I think Shuhao separated spell and normal attack
    public void upgradeAtkDamage(float i)
    {
        //located in upgrade controller
    }

    public void upgradeJump(float i)
    {
        Jumpforce += i;
    }

    //Need to modify bullet prefab for spell damage
    public void upgradeSpellDamage(float i)
    {
        //located in upgrade controller
    }

    public void upgradeMultiplier()
    {
        coinMultiplier *= 1.5f;
    }

    public void enableRockSteady()
    {
        isRockSteady = true;
    }

    public void resetDefaults()
    {
        isRockSteady = false;
        speed = 10f;
        Jumpforce = 10f;
        coinMultiplier = 1;
        bullet.GetComponent<Bullet>().resetBulletDamage();
        trapBullet.GetComponent<TrapBullet>().resetBulletDamage();
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
