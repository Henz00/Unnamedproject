using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupHUD : MonoBehaviour
{
    public Slider m_PickUpSlider;
    public float datascore = 0;

    void Start()
    {
        m_PickUpSlider.value= 0F;
    }


    void Update()
    {
        m_PickUpSlider.value = datascore;
    }
}
