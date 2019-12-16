using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilitySecondManager : MonoBehaviour
{
    private InterButton SecondPuzzleButton;
    private GameObject SecondPuzzlePlatform;
    private GameObject SecondPuzzleDoor;

    void Start()
    {
        SecondPuzzleButton = GetComponentInChildren<InterButton>();
        SecondPuzzleDoor = GameObject.Find("SecondPuzzleDoor");
    }

    
    void Update()
    {
        if (SecondPuzzleButton.active)
        {
            SecondPuzzleDoor.SetActive(false);
        }
        else
        {
            SecondPuzzleDoor.SetActive(true);
        }
    }
}
