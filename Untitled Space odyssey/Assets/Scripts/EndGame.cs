using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private EndLevelFade endlevelfade;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player 1") || other.CompareTag("Player 2"))
        {
            endlevelfade.camerashake();
        }
    }
  
}
