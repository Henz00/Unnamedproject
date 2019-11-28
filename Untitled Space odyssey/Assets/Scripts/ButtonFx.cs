using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFx : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hover;
    public AudioClip click;

    public void HoverSound()
    {
        source.PlayOneShot(hover);
    }
    public void ClickSound()
    {
        source.PlayOneShot(click);
    }
}
