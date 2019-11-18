using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textTrigger : MonoBehaviour
{
    public Canvas AreaText;
    public Animator TextAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        AreaText.enabled = false;
        TextAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Palyer 1" || other.tag == "Player 2")
        {
            TextAnimator.enabled = true;
            AreaText.enabled = true;
        }
    }
}
