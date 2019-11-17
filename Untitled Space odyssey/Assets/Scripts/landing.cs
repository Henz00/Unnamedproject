using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landing : MonoBehaviour
{
    private ParticleSystem landDust;
    private void Start()
    {
        landDust = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            landDust.Play();
        }
    }
}
