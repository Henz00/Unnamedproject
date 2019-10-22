using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 30;
    public bool jump = false;
    public bool grounded = true;
    public float maxspeed = 10;
    public float jumpspeed = 10;
    public Transform groundCheck;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rh = Physics2D.Linecast(transform.position, groundCheck.position, mask);
        if (rh.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
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

        if (jump && grounded)
        {

            rb.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
            jump = false;
        }
    }
}
