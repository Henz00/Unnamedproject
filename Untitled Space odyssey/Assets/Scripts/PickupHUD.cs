using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupHUD : MonoBehaviour
{
    public Slider m_PickUpSlider;
    public float datascore = 0;

    private GameObject[] dataObjects;

    void Start()
    {
        m_PickUpSlider.value= 0F;

        dataObjects = GameObject.FindGameObjectsWithTag("data");
        m_PickUpSlider.maxValue = dataObjects.Length;
      
    }


    void Update()
    {
        if (datascore > m_PickUpSlider.value)
        {
            m_PickUpSlider.value = m_PickUpSlider.value + 0.02f;
        }
    }
}
