using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouldersprite : MonoBehaviour
{
    public GameObject Rock;
    public float Rotatespeed = 100;

    void Start()
    {
        Rock.GetComponent<Boulder>();
    }


    void Update()
    {
        if(Rock.GetComponent<Boulder>().Rotating == true)
        {
            transform.Rotate(Vector3.back * Rotatespeed * Time.deltaTime);
        }
        else if(Rock.GetComponent<Boulder>().Rotating == false)
        {
            transform.Rotate(0, 0, 0);
        }
    }

}
