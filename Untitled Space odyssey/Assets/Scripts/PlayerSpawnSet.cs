using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnSet : MonoBehaviour
{
    public GameObject SpawnManager;

    public static Vector3 spawnPointSet;

    CheckPointManager checkpointmanager;

    void Awake()
    {
        SpawnManager = GameObject.FindGameObjectWithTag("checkPointManager");
        checkpointmanager = SpawnManager.GetComponent<CheckPointManager>();
        spawnPointSet = checkpointmanager.spawnPoint;
        checkpointmanager.spawn++;

    }

    void Start()
    {
        if (checkpointmanager.spawn > 1)
        {
            gameObject.transform.position = spawnPointSet;
        }
    }

}
