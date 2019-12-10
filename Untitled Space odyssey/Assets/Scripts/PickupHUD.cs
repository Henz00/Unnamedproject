using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupHUD : MonoBehaviour
{
    public float datascore;

    public Slider m_PickUpSlider;
    private static PickupHUD instance = null;
    private GameObject[] dataObjects;

    void Awake()
    {
        FindSlider();

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
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

    Slider FindSlider()
    {
        m_PickUpSlider = FindObjectOfType<Slider>();
        return m_PickUpSlider;
    }
}
