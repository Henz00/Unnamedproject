using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    public float SleepTime;
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            StartCoroutine(TimeSleep());
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
