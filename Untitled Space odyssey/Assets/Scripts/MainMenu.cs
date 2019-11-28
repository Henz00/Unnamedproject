using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        Invoke("loadGame",.4f);
        Debug.Log("LoadScene");
    }

    public void loadGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Invoke("quit", .4f);
    }

    public void quit()
    {
        Application.Quit();
    }

}
