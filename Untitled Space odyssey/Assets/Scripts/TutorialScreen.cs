using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TutorialScreen : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Other;

    // Start is called before the first frame update
    void Start()
    {
        Player1.SetActive(true);
        Player2.SetActive(false);
        Other.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

