using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECHO : MonoBehaviour
{
    public int playerDeaths = 0;
    public AudioClip deathClip = null;
    public AudioSource EchoSource;
    public AudioClip[] deathClips;

    private static ECHO instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        EchoSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void changeClip()
    {
 
        if (playerDeaths > 0)
        {
            deathClip = deathClips[Random.Range(0, deathClips.Length)];
            EchoSource.clip = deathClip;
        }
    }
}
