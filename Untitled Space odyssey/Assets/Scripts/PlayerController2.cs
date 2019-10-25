using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 30;
    public bool jump = false;
    public bool grounded = true;
    public float maxspeed = 10;
    public float jumpspeed = 10;
    public LayerMask layerMask;


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
        if (boxCheck())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                jumping();
            }
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal 2");
        rb.AddForce(h * Vector2.right * speed);

        if (Mathf.Abs(rb.velocity.x) > maxspeed)
        {
            float sign = Mathf.Sign(rb.velocity.x);
            rb.velocity = new Vector2(sign, rb.velocity.y);
        }
       
    }
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        jump = true;
    }*/
    void jumping()
    {
        rb.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        pickup.Play();
        other.gameObject.SetActive(false);
    }

    private bool boxCheck()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(transform.position, new Vector2(1.9f,.4f), 0f, new Vector2(0, -1),distance: .4f, layerMask);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
}
