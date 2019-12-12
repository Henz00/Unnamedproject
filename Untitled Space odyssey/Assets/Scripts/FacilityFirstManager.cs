using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityFirstManager : MonoBehaviour
{
    private InterButton FirstPuzzleButton;
    private GameObject FirstPuzzleDoor;

    void Start()
    {
        FirstPuzzleButton = GetComponentInChildren<InterButton>();
        FirstPuzzleDoor = GameObject.Find("FirstPuzzleDoor");
    }

   
    void Update()
    {
        if (FirstPuzzleButton.active)
            FirstPuzzleDoor.SetActive(false);
        else
            FirstPuzzleDoor.SetActive(true);
    }
}
