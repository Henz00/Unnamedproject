using System.Collections;
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
    public float restarttime = 1f;
    public int Health = 3;
    public LayerMask playerMask;
    public LayerMask dustMask;
    public Text Gameover;

    private AudioSource AS;
    public AudioClip Jumpsound;
    public AudioClip Damagetakensound;

    public Animator animator;
    public ParticleSystem dust;

<<<<<<< HEAD
    private float originalPitch;    
    private float movement;
    private float movementSpeed;
    private bool facingRight;    

    // Start is called before the first frame update
    void Start()
    {                
=======

    private float originalPitch;
    private bool facingRight;
    private float movement;
    private float movementSpeed;

    public AudioSource jumpSound;
    public ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {

>>>>>>> master
        rb = GetComponent<Rigidbody2D>();
        AS = GetComponent<AudioSource>();

        facingRight = true;
        //originalPitch = jumpSound.pitch;
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

        if(Health <= 0)
        {        
            StartCoroutine("Death");
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
            Health = Health - 1;
            AS.PlayOneShot(Damagetakensound, pitchRange);
            rb.AddForce(Vector2.up * damagejumpforce, ForceMode2D.Impulse);
            Debug.Log("touchinghurts");
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
        //AS.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
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

<<<<<<< HEAD
    public IEnumerator Death()
    {
        Time.timeScale = slowmo;
        Gameover.text = "YOU DIED!";
        yield return new WaitForSeconds(restarttime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   

=======
>>>>>>> master
}
   
