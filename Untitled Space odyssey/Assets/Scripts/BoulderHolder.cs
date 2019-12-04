using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderHolder : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Boulder;
    public int BoulderSpawn;

    private bool player1IN;
    private bool player2IN;

    // Start is called before the first frame update
    public void Start()
    {
        Boulder.SetActive(false);
        BoulderSpawn = 0;
        player1IN = false;
        player2IN = false;
    }

    public void Update()
    {
        if(BoulderSpawn == 2)
        {
            Boulder.SetActive(true);
            Debug.Log("Indiana Jones Baby!");
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player 1") && player1IN == false)
        {
            BoulderSpawn++;
            player1IN = true;
            Debug.Log("player1IN");
        }

        if (other.gameObject.CompareTag("Player 2") && player2IN == false)
        {
            BoulderSpawn++;
            player2IN = true;
            Debug.Log("player2IN");
        }
    }
}
