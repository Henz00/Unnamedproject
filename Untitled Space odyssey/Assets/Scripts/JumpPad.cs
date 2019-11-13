using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpPad : MonoBehaviour

{
    public float jumpboost = 10;

    private Rigidbody2D rg;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            rg = other.gameObject.GetComponent<Rigidbody2D>();
            rg.AddForce(Vector2.up * jumpboost, ForceMode2D.Impulse);
            //Debug.Log("JumpBoost!");
        }
    }
}
