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
        SecondPuzzlePlatform = GameObject.Find("SecondPuzzlePlatform");
        SecondPuzzleDoor = GameObject.Find("SecondPuzzleDoor");
    }

    
    void Update()
    {
        if (SecondPuzzleButton.active)
        {
            SecondPuzzlePlatform.SetActive(true);
            SecondPuzzleDoor.SetActive(false);
        }
        else
        {
            SecondPuzzlePlatform.SetActive(false);
            SecondPuzzleDoor.SetActive(true);
        }
    }
}
