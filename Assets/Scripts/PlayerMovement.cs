using UnityEngine;
using UnityEngine.Audio;


public class PlayerMovement : MonoBehaviour
{
    public float jump;
    private float length;
    private bool isGrounded;
    private bool isSliding;
    private Rigidbody2D rb;
    private GameManager gm;
    private AudioManager am;
    public GameObject shieldObject;
    private bool haveShield;


    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        am = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        gm.scoreText.text = gm.score.ToString();
    }

    void Update()
    {
        if (isGrounded && !isSliding)
        {
            Jump();

        }
        if (!isGrounded)
        {
            Downforce();

        }
        Slide();
        GetUp();

        if (haveShield)
        {
            shieldObject.SetActive(true);
        }
        else if (!haveShield)
        {
            shieldObject.SetActive(false);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!haveShield)
            {
                gm.GameOverScreen.SetActive(true);
                Time.timeScale = 0;
                am.audioSource.Stop();
                am.PlayDieSfx();
            }
            if (haveShield)
            {
                am.PlayShieldBreakSfx();
                haveShield = false;
            }
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            gm.score++;
            gm.scoreText.text = gm.score.ToString();
            Destroy(other.gameObject);
            am.PlayPickUpSfx();
        }
        if (other.gameObject.CompareTag("ShieldPowerUp"))
        {
            if (haveShield)
            {
                gm.score += 2;
                gm.scoreText.text = gm.score.ToString();
            }
            haveShield = true;
            Destroy(other.gameObject);
            am.PlayPickUpSfx();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jump);
        }
    }
    void Downforce()

    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * jump);
        }
    }
    void Slide()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale = new Vector2(transform.localScale.x, 0.5f);
            isSliding = true;
        }
    }
    void GetUp()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localScale = new Vector2(transform.localScale.x, 1f);
            isSliding = false;
        }
    }
}