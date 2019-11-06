using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupHUD : MonoBehaviour
{
    public Slider m_PickUpSlider;
    public float datascore = 0;

    private ArrayList datalist;

    void Start()
    {
        m_PickUpSlider.value= 0F;
        //m_PickUpSlider.maxValue = ;

       
    }


    void Update()
    {
        m_PickUpSlider.value = datascore;
    }
}
