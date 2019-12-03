using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask layerMask;
    public LayerMask PlayerMask;
    public LayerMask Player1Mask;
    public LayerMask Player2Mask;
    public LayerMask SquishChecker;
    public int move = 1;
    public float speed;
    public bool canMove = true;
    public GameObject attack1;
    public GameObject attack2;
    public AudioSource squisher;

    private Collider2D col;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(transform.position, new Vector2(1.9f, 1f), 0f, new Vector2(0, 1), distance: 1F, PlayerMask);


        if (col.IsTouchingLayers(Player1Mask) && col.IsTouchingLayers(Player2Mask))
        {
            Debug.Log("squish");
            Invoke("death", 1f);
        }
        else if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.CompareTag("Player 1"))
                SquishChecker = Player2Mask;
            else if (raycastHit2D.collider.CompareTag("Player 2"))
                SquishChecker = Player1Mask;
            if (PlayerCheck(SquishChecker, raycastHit2D.transform))
            {
                Debug.Log("squish");
                death();
            }
        }


        if (PlayerCheck(PlayerMask, transform))
        {
                canMove = false;
        }
        else
            canMove = true;

        if (boxCheckRight(layerMask))
        {
            move = -1;
        }
        else if (boxCheckLeft(layerMask))
        {
            move = 1;
        }

        if ( canMove)
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

    }

    private void death()
    {
        squisher.Play();
        col.enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        attack1.SetActive(false);
        attack2.SetActive(false);
        //gameObject.SetActive(false);
    }

    private bool boxCheckRight(LayerMask layerMask)
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(transform.position, new Vector2(1.1f, 1f), 0f, new Vector2(1, 0), distance: 1F, layerMask);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
    private bool boxCheckLeft(LayerMask layerMask)
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(transform.position, new Vector2(1.1f, 1f), 0f, new Vector2(-1, 0), distance: 1F, layerMask);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
    private bool PlayerCheck(LayerMask layerMask, Transform checkTransform)
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(checkTransform.position, new Vector2(1.9f, 1f), 0f, new Vector2(0, 1), distance: 1F, layerMask);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
}
