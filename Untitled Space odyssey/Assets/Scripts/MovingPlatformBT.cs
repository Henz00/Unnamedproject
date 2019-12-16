using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBT : MonoBehaviour
{
    public float speed;
    public Transform PointA;
    public Transform PointB;

    private InterButton Button;

    // Start is called before the first frame update
    void Start()
    {
        Button = GameObject.FindGameObjectWithTag("secondButton").GetComponent<InterButton>();
    }

    // Update is called once per frame
    private void Update()
    {

        float step = speed * Time.deltaTime;
        if (Button.active == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointA.position, step);            
        }
        if (Button.active == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointB.position, step);            
        }
    }
}