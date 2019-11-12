using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatform : MonoBehaviour
{
    public float speed;
    public bool MovingToA;
    public Transform PointA;
    public Transform PointB;
    public GameObject Player1;
    public GameObject Player2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        float step = speed * Time.deltaTime;
        if (MovingToA == true && transform.position != PointA.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointA.position, step);
            if (transform.position == PointA.position)
            {
                MovingToA = false;                
            }
        }
        if (MovingToA == false && transform.position != PointB.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointB.position, step);
            if (transform.position == PointB.position)
            {
                MovingToA = true;                
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player1)
        {
            Player1.transform.parent = transform;
        }

        if (collision.gameObject == Player2)
        {
            Player1.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == Player1)
        {
            Player1.transform.parent = null;
        }

        if (collision.gameObject == Player2)
        {
            Player1.transform.parent = null;
        }
    }
}
