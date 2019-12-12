using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterButton : MonoBehaviour
{
    private bool interactable = false;
    public bool active = false;
    public AudioSource buttonSound;


    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown("e"))
            {
                if (!active)
                {
                    Debug.Log("Activated button!");
                    active = true;
                    buttonSound.Play();

                }
                else
                {
                    Debug.Log("Deactivated button!");
                    active = false;
                    buttonSound.Play();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactable = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactable = false;
    }
}
