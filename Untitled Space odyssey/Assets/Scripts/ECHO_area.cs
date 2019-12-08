using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECHO_area : MonoBehaviour
{
    private GameObject ECHO;

    public AudioClip areaClip;
    public bool active = true;
    public string ECHO_emotion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Player 1" || other.tag == "Player 2") && active == true)
        {
            ECHO = GameObject.Find("ECHO");

            ECHO.GetComponent<AudioSource>().clip = areaClip;
            ECHO.GetComponent<AudioSource>().Play();
            active = false;
            ECHO.GetComponent<ECHO>().changeClip();
            ECHO.GetComponent<ECHO>().changeSprite(ECHO_emotion);
        }
    }
 
}
