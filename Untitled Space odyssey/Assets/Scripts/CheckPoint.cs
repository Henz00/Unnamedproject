using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public static Vector3 nextSpawn;

    private BoxCollider2D col;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player 1") || other.collider.CompareTag("Player 2"))
        {
            nextSpawn = gameObject.transform.position;
        }
    }

    public Vector3 GetNextSpawn()
    {
        return nextSpawn;
    }

    void Update()
    {
        //Debug.Log(nextSpawn);
    }

}
