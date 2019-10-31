using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour

{
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Debug.Log("hit");
        }
    }
}
