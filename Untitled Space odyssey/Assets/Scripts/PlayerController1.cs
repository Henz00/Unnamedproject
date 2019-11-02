﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 30;
    public float maxspeed = 10;
    public float jumpspeed = 10;
    public LayerMask layerMask;
    public float pitchRange = 0.2f;

    
    private float originalPitch;

   
    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
       

        originalPitch = jumpSound.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCheck())
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumping();
            }
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        /*rb.AddForce(h * Vector2.right * speed);

        if (Mathf.Abs(rb.velocity.x) > maxspeed)
        {
            float sign = Mathf.Sign(rb.velocity.x);
            rb.velocity = new Vector2(sign, rb.velocity.y);
        }*/
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
    }


    private bool boxCheck()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(transform.position, new Vector2(.9f, 1.5f), 0f, new Vector2(0, -1), distance: 1.5F, layerMask);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
}
   
