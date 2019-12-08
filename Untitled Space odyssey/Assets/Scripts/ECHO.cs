using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ECHO : MonoBehaviour
{
    public int playerDeaths = 0;
    public AudioClip deathClip = null;
    public AudioSource EchoSource;
    public AudioClip[] deathClips;
    public GameObject ECHOBox;
    public Sprite ECHO_happy;
    public Sprite ECHO_sad;
    public Sprite ECHO_neutral;

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
    
    void Update()
    {
        if (EchoSource.isPlaying)
            ECHOBox.SetActive(true);
        else
            ECHOBox.SetActive(false);
    }

    public void changeSprite(string emotion)
    {
        if (emotion == "happy")
            ECHOBox.GetComponent<Image>().sprite = ECHO_happy;
        else if(emotion == "sad")
            ECHOBox.GetComponent<Image>().sprite = ECHO_sad;
        else if (emotion == "neutral")
            ECHOBox.GetComponent<Image>().sprite = ECHO_neutral;
    }
}
