using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushing : MonoBehaviour
{
    private Rigidbody2D rb;
    public ParticleSystem dust;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (rb.velocity.x > 0)
        {
            dust.Play();
        }
    }
}
