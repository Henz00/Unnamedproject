using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleDoor : MonoBehaviour
{
    private BoxCollider2D kasse;
    private bool activated;

    void Start()
    {
        kasse = gameObject.GetComponentInChildren<BoxCollider2D>();
    }
    void Update()
    {
        activated = gameObject.GetComponentInChildren<Interactable>().activate;

        if (activated) 
        {
            kasse.enabled = false;
        }  
        else
        {
            kasse.enabled = true;
        }        
    }
}
