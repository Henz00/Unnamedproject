using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private EndLevelFade endlevelfade;

    void Start()
    {
        endlevelfade = GetComponent<EndLevelFade>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player 1") || other.CompareTag("Player 2"))
        {
            endlevelfade.camerashake();
            Invoke("ChangeToEndScene", 2);
        }
    }

    void ChangeToEndScene()
    {
        SceneManager.LoadScene(4);
    }
  
}
