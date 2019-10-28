using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    private bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isActivated == false)
        {
            isActivated = true;
            Menu.SetActive(true);
            Time.timeScale = 0f;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && isActivated == true)
        {
            isActivated = false;
            Menu.SetActive(false);
            Time.timeScale = 1f;
        }



    }


    public void RestartLevel()
    {
        // Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeLevel()
    {
        Menu.SetActive(false);
        isActivated = false;
        Time.timeScale = 1f;
    }



}