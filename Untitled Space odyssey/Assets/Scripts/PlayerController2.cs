using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 30;
    public float maxspeed = 10;
    public float jumpspeed = 10;
    public LayerMask layerMask;
    public float pitchRange = 0.2f;

    private PickupHUD datacounter;
    private float originalPitch;

    public AudioSource pickup;
    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        datacounter = GetComponentInParent<PickupHUD>();

        originalPitch = jumpSound.pitch;
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

        jumpSound.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
        jumpSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        pickup.Play();
        other.gameObject.SetActive(false);
        datacounter.datascore++;
    }

    private bool boxCheck()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(transform.position, new Vector2(2.9f,.7f), 0f, new Vector2(0, -1),distance: .7f, layerMask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
}
