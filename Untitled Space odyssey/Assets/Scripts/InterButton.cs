using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterButton : MonoBehaviour
{
    private bool interactable = false;
    public bool active = false;


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

                }
                else
                {
                    Debug.Log("Deactivated button!");
                    active = false;
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
