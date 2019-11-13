using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2);
        Debug.Log("LoadScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
