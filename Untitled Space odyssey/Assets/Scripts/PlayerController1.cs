﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 30;
    public float maxspeed = 10;
    public float jumpspeed = 10;
    public LayerMask playerMask;
    public LayerMask dustMask;
    public float pitchRange = 0.2f;
    public Animator animator;

    
    private float originalPitch;
    private bool facingRight;
    private float movement;
   
    public AudioSource jumpSound;
    public ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        facingRight = true;
        originalPitch = jumpSound.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCheck(playerMask))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumping();                
            }
        }

        if (boxCheck(playerMask))
        {
            animator.SetBool("jumpcheck", false);
        }
        else
            animator.SetBool("jumpcheck", true);
    }

    private void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(movement));
        /*rb.AddForce(h * Vector2.right * speed);

        if (Mathf.Abs(rb.velocity.x) > maxspeed)
        {
            float sign = Mathf.Sign(rb.velocity.x);
            rb.velocity = new Vector2(sign, rb.velocity.y);
        }*/
        changeDirection(movement);
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        jump = true;
    }*/

    void jumping()
    {
        rb.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
        jumpSound.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
        jumpSound.Play();


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

   

}
   
