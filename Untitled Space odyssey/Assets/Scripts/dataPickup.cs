using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataPickup : MonoBehaviour
{
    public AudioSource pickup;
    public AudioSource ECHO;
    public ParticleSystem burst;
    public ParticleSystem sparks;
    public float SleepTime;
    public AudioClip[] lines;

    private PickupHUD datacounter;
    // Start is called before the first frame update
    void Start()
    {
        datacounter = GetComponentInParent<PickupHUD>();
        
    }

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player 1" || other.tag == "Player 2")
        {
            pickup.Play();
            datacounter.datascore++;
            if ( datacounter.datascore > 1)
            {
                ECHO.clip = lines[Random.Range(0, lines.Length)];
            }
            ECHO.Play();
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            sparks.Stop();
            burst.Play();
            StartCoroutine(TimeSleep());
            //gameObject.SetActive(false);

        }
    }

    IEnumerator TimeSleep()
    {
        if (Time.timeScale == 1.0f)
            Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(SleepTime);
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }
}
