using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Vector3 spawnPoint;
    public int spawn;

    private static CheckPointManager instance = null;
    private Vector3 checkVector = new Vector3(0f, 0f, 0f);

    public CheckPoint checkpoint;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (GetComponentsInChildren<CheckPoint>().Length > 0)
        {
            checkpoint = GetComponentsInChildren<CheckPoint>()[0];

            if (checkpoint != null)
            {
                if (checkpoint.GetNextSpawn() != checkVector && checkpoint.GetNextSpawn() != spawnPoint)
                {
                    spawnPoint = checkpoint.GetNextSpawn();
                    checkpoint.gameObject.SetActive(false);
                }
            }
        }
    }

}
