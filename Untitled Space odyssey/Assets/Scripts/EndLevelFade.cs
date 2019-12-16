using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelFade : MonoBehaviour
{
    public Animator FadetoBlack;

    public void camerashake()
    {
        FadetoBlack.SetTrigger("FadetoBlack");
    }
}
