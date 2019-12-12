﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
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

    private GameObject ECHO;
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
        ECHO = GameObject.Find("ECHO");

        ECHO.GetComponent<ECHO>().changeClip();
        if (ECHO.GetComponent<ECHO>().playerDeaths>0)
            ECHO.GetComponent<ECHO>().changeSprite("sad");
        ECHO.GetComponent<AudioSource>().Play();

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
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    jumping();
                }
                animator.SetBool("jumpcheck", false);
                movementSpeed = speed;
            }
            else
            {
                animator.SetBool("jumpcheck", true);
                movementSpeed = speed / speedDivider;
            }

            /*if (boxCheck(playerMask))
            {
                animator.SetBool("jumpcheck", false);
            }
            else
                animator.SetBool("jumpcheck", true);*/


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
                if (!dead)
                {
                    dead = true;
                    Time.timeScale = slowmo;
                    explosion.Play();
                    //AS.PlayOneShot(deathSound, pitchRange);
                    ECHO.GetComponent<ECHO>().playerDeaths++;
                    animator.SetBool("Death", true);
                    //Gameover.text = "YOU DIED!";
                    Invoke("Restartlevel", RestartTime);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * movementSpeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(movement));
        changeDirection(movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage1"))
        {
            Health--;
            AS.PlayOneShot(Damagetakensound, pitchRange);
            rb.AddForce(Vector2.up * damagejumpforce, ForceMode2D.Impulse);

            animator.SetTrigger("DamageTaken");
            Debug.Log("RedWhiteStuff");
        }
        if (collision.gameObject.CompareTag("water"))
        {
            Health--;
            AS.PlayOneShot(Damagetakensound, pitchRange);
            rb.AddForce(Vector2.up * damagejumpforce, ForceMode2D.Impulse);
            animator.SetTrigger("DamageTaken");
            Debug.Log("touchinghurts");
            water.Play();
            Debug.Log("water");
        }
        if (collision.gameObject.CompareTag("Boulder"))
        {
            Health = 0;
            AS.PlayOneShot(Damagetakensound, pitchRange);
            animator.SetTrigger("DamageTaken");
            Debug.Log("RedWhiteStuff");
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
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(transform.position, new Vector2(1.1f, 1f), 0f, new Vector2(0, -1), distance: 1F, layerMask);
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
}
 
   
