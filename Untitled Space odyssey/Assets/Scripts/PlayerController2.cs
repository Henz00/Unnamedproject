using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 30;
    public float maxspeed = 10;
    public float jumpspeed = 10;
    public float speedDivider = 2f;
    public float damagejumpforce = 10;
    public float pitchRange = 0.2f;
    public float slowmo = 0.8f;
    public float RestartTime = 1f;
    public int Health = 3;
    public LayerMask playerMask;
    public LayerMask dustMask;
    //public Text Gameover;
    public GameObject EyeCrack;
    public GameObject Orange;
    public GameObject Red;

    private AudioSource AS;
    public AudioClip Jumpsound;
    public AudioClip Damagetakensound;
    public AudioClip deathSound;

    public Animator animator;
    public ParticleSystem dust;
    public ParticleSystem water;
    public ParticleSystem explosion;

    private Shaker shake;
    private float originalPitch;    
    private float movement;
    private float movementSpeed;
    private bool facingRight;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        AS = GetComponent<AudioSource>();
        shake = GameObject.Find("CameraShaker").GetComponent<Shaker>();

        EyeCrack.SetActive(false);
        Orange.SetActive(false);    
        Red.SetActive(false);

        facingRight = true;
        //originalPitch = jumpSound.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (boxCheck(playerMask))
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    jumping();
                }
                animator.SetBool("jumpcheck2", false);
                movementSpeed = speed;
            }
            else
            {
                animator.SetBool("jumpcheck2", true);
                movementSpeed = speed / speedDivider;
            }

            /*if (boxCheck(playerMaskanimator.SetBool("jumpcheck2", true)))
            {
                animator.SetBool("jumpcheck2", false);
            }
            else
                animator.SetBool("jumpcheck2", true);*/

            if (Health == 2)
            {
                Orange.SetActive(true);
                EyeCrack.SetActive(false);
                Red.SetActive(false);
            }

            if (Health <= 1)
            {
                Orange.SetActive(false);
                EyeCrack.SetActive(true);
                Red.SetActive(true);
            }

            if (Health <= 0)
            {
                Time.timeScale = slowmo;
                explosion.Play();
                //AS.PlayOneShot(deathSound, pitchRange);
                animator.SetBool("Death", true);
                //Gameover.text = "YOU DIED!";
                Invoke("Restartlevel", RestartTime);
            }
        }
    }

    private void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal 2");
        rb.velocity = new Vector2(movement * movementSpeed, rb.velocity.y);

        animator.SetFloat("Speed2", Mathf.Abs(movement));
        changeDirection(movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage1"))
        {
            Health = Health - 1;
            AS.PlayOneShot(Damagetakensound, pitchRange);
            rb.AddForce(Vector2.up * damagejumpforce, ForceMode2D.Impulse);
            Debug.Log("touchinghurts");
            shake.camerashake();
            animator.SetTrigger("DamageTaken");
        }
        if (collision.gameObject.CompareTag("water"))
        {
            Health = Health - 1;
            AS.PlayOneShot(Damagetakensound, pitchRange);
            rb.AddForce(Vector2.up * damagejumpforce, ForceMode2D.Impulse);
            animator.SetTrigger("DamageTaken");
            Debug.Log("touchinghurts");
            shake.camerashake();
            water.Play();
            Debug.Log("water");
        }
        if (collision.gameObject.CompareTag("Boulder"))
        {
            Health = 0;
            AS.PlayOneShot(Damagetakensound, pitchRange);
            animator.SetTrigger("DamageTaken");
            shake.camerashake();
            Debug.Log("RedWhiteStuff");
        }

        if (collision.gameObject.CompareTag("Damage2"))
        {
            Health = Health - 2;
        }

        if (collision.gameObject.CompareTag("Damage3"))
        {
            Health = Health - 2;
        }
    }   

    void jumping()
    {
        rb.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
        AS.PlayOneShot(Jumpsound, pitchRange);

        if (boxCheck(dustMask))
        {
            dust.Play();
        }
    }

    private bool boxCheck(LayerMask layerMask)
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(transform.position, new Vector2(2.4f,.6f), 0f, new Vector2(0, -1),distance: .6f, layerMask);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }

    private void changeDirection(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            if (boxCheck(dustMask))
            {
                dust.Play();
            }
        }
    }

    void Restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision other)
    {
        if (other.gameObject.layer == 4)
        {
            water.Play();
        }
    }
}
