using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    public GameObject SettingsCanvas;
    public GameObject AudioPage;

    void Start()
    {
        Time.timeScale = 1f;
        PauseMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }

    }
    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;

    }
    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;

    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        
    }

    public void Settings()
    {
        Time.timeScale = 0f;
        PauseMenuCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
        AudioPage.SetActive(true);

    }

    public void BackToPauseMenu()
    {
        Time.timeScale = 0f;
        PauseMenuCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
    }

    
}
