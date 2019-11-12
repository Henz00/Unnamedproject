using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMainMenu : MonoBehaviour
{

    private float width;
    private float height;
    private float startposX;
    private float startposY;

    public float scrollSpeed;
    public Transform moveTo;
    // Start is called before the first frame update
    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - .1f * scrollSpeed*1.778f, transform.position.y - .1f * scrollSpeed, transform.position.z);

        if (transform.position.x <= moveTo.position.x-width*2 && transform.position.y <= moveTo.position.y-height*2)
        {
            transform.position = new Vector3 (moveTo.position.x,moveTo.position.y,transform.position.z);
        }
    }
}

