using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterButton : MonoBehaviour
{
    private static bool interactable = false;
    private bool activate = false;


    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown("e"))
            {
                if (!activate)
                {
                    Debug.Log("Activated button!");
                    activate = true;

                }
                else
                {
                    Debug.Log("Deactivated button!");
                    activate = false;
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
