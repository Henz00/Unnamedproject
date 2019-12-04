using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public float speed;
    public bool MovingToA;
    public bool MovingToB;
    public bool Rotating;
    public Transform PointA;
    public Transform PointB;
    public GameObject B;

    // Update is called once per frame
    public void Start()
    {
        MovingToA = true;
        MovingToB = true;
        B.SetActive(true);
        Rotating = true;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        if (MovingToB == true && transform.position != PointB.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointB.position, step);
            if (transform.position == PointB.position)
            {
                MovingToB = false;
                MovingToA = false;
                B.SetActive(false);                
            }
        }
        if (MovingToA == false && transform.position != PointA.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointA.position, step);
            if (transform.position == PointA.position)
            {
                MovingToA = false;
                Rotating = false;
                
            }
        }
    }
}
