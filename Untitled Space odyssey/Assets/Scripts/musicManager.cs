using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour
{
    private bool level = false;
    private AudioSource source;

    public AudioClip levelClip;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        source = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3) && level == false)
        {
            level = true;
            source.clip = levelClip;
            source.Play();
        }
    }
}
