using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public Animator CameraAnimation;

    public void camerashake()
    {
        CameraAnimation.SetTrigger("shake");
    }
}
