using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    public GameObject Rock;
    public float Startspawner;
    public float RepeatRate;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateRock", Startspawner, RepeatRate);
    }

    void CreateRock()
    {
        Instantiate(Rock,transform);
    }
}

