using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHelper : MonoBehaviour
{
    private static DataHelper instance = null;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

            DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (!(SceneManager.GetSceneByName("SampleScene 1").isLoaded))
        {
            Destroy(gameObject);
        }
    }
}
