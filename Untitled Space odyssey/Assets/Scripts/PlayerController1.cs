using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 30;
    public bool jump = true;
    public float maxspeed = 10;
    public float jumpspeed = 10;
    public Transform groundCheck;
    public LayerMask mask;
    public int data = 0;

    AudioSource pickup;


    // Start is called before the first frame update
    void Start()
    {
        pickup = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump)
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
        rb.AddForce(h * Vector2.right * speed);

        if (Mathf.Abs(rb.velocity.x) > maxspeed)
        {
            float sign = Mathf.Sign(rb.velocity.x);
            rb.velocity = new Vector2(sign, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jump = true;
    }

    void jumping()
    {
        rb.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("dingding");
        other.gameObject.SetActive(false);
        data++;
        pickup.Play(0);
    
    }
    }
