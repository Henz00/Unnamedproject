using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataPickup : MonoBehaviour
{
    AudioSource pickup;
    public ParticleSystem burst;
    public ParticleSystem sparks;
    public float SleepTime;

    private PickupHUD datacounter;
    // Start is called before the first frame update
    void Start()
    {
        datacounter = GetComponentInParent<PickupHUD>();
        pickup = GetComponent<AudioSource>();
    }

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player 1" || other.tag == "Player 2")
        {
            pickup.Play();
            datacounter.datascore++;
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
