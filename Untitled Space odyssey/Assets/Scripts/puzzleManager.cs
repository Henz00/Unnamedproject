using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleManager : MonoBehaviour
{

    private InterButton interbuttonRight;
    private InterButton interbuttonLeft;
    private InterButton interbuttonCenter;
    private GameObject DoorRight;
    private GameObject DoorLeft;
    private GameObject DoorFacility;


    void Start()
    {
        interbuttonRight = GetComponentsInChildren<InterButton>()[0];
        interbuttonLeft = GetComponentsInChildren<InterButton>()[1];
        interbuttonCenter = GetComponentsInChildren<InterButton>()[2];
        DoorRight = GameObject.Find("DoorButtonRight");
        DoorLeft = GameObject.Find("DoorButtonLeft");
        DoorFacility = GameObject.Find("DoorFacility");
    }


    void Update()
    {
        if (interbuttonCenter.active)
            DoorLeft.SetActive(false);
        else
            DoorLeft.SetActive(true);

        if (interbuttonCenter.active && interbuttonLeft.active)
        {
            DoorLeft.SetActive(true);
            DoorRight.SetActive(false);
        }

        if(!interbuttonCenter.active && interbuttonLeft.active)
        {
            DoorLeft.SetActive(false);
        }

        if (interbuttonRight.active)
        {
            DoorFacility.SetActive(false);
            DoorRight.SetActive(true);
        }

        if(interbuttonCenter.active && interbuttonRight.active)
        {
            DoorRight.SetActive(false);
        }


            
            

    }
}
