using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loreDump : MonoBehaviour
{
    public float datascore;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject box5;
    public GameObject box6;
    public GameObject box7;
    public GameObject box8;
    public GameObject box9;
    public GameObject box10;
    public GameObject box11;
    public GameObject box12;
    public GameObject box13;
    public GameObject box14;
    public GameObject box15;

    private PickupHUD dataStorage;

    void Start()
    {
        dataStorage = GameObject.Find("LevelData").GetComponent<PickupHUD>();

    
        box1.SetActive(false);

        box2.SetActive(false);
  
        box3.SetActive(false);
  
        box4.SetActive(false);
 
        box5.SetActive(false);

        box6.SetActive(false);

        box7.SetActive(false);

        box8.SetActive(false);

        box9.SetActive(false);

        box10.SetActive(false);

        box11.SetActive(false);

        box12.SetActive(false);

        box13.SetActive(false);

        box14.SetActive(false);

        box15.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        datascore = dataStorage.datascore;

        if (datascore >= 1)
            box1.SetActive(true);
        if (datascore >= 2)
            box2.SetActive(true);
        if (datascore >= 3)
            box3.SetActive(true);
        if (datascore >= 4)
            box4.SetActive(true);
        if (datascore >= 5)
            box5.SetActive(true);
        if (datascore >= 6)
            box6.SetActive(true);
        if (datascore >= 7)
            box7.SetActive(true);
        if (datascore >= 8)
            box8.SetActive(true);
        if (datascore >= 9)
            box9.SetActive(true);
        if (datascore >= 10)
            box10.SetActive(true);
        if (datascore >= 11)
            box11.SetActive(true);
        if (datascore >= 12)
            box12.SetActive(true);
        if (datascore >= 13)
            box13.SetActive(true);
        if (datascore >= 14)
            box14.SetActive(true);
        if (datascore >= 15)
            box15.SetActive(true);
    }
}
