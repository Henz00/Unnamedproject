using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    
    private static bool interactable = false;
    public bool activate = false;
 

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown("e"))
            {
                if (!activate)
                {
                    Debug.Log("Activated!");
                    Quaternion previous = gameObject.transform.parent.rotation;
                    gameObject.transform.parent.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1)) * previous;
                    activate = true;
  
                }
                else
                {
                    Debug.Log("Deactivated!");
                    Quaternion previous = gameObject.transform.parent.rotation;
                    gameObject.transform.parent.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1)) * previous;
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
