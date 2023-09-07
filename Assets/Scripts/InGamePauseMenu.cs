using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //has to be included for scene transitions

public class InGamePauseMenu : MonoBehaviour
{
    public static bool Paused = false; //static bool means that this variable can be accessed outside of this script by referring to its class name.
    public GameObject PauseMenuCanvas;
    public GameObject SettingsCanvas;
    public GameObject AudioPage; //declares the variables, and in unity editor, there will be fields that I can assign these variables to the actual gameobjects therefore acquiring their data

    void Start()
    {
        Time.timeScale = 1f;
        PauseMenuCanvas.SetActive(false); //when the game started, the time is 1f as normal, and the pause menu canvas is set as inactive so the player doesn't see it.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //if the key is pressed
        {
            if (Paused) //if the current state of the game is paused, clicking the esc button would resume the game
            {
                Play();
            }
            else //otherwise the game is paused.
            {
                Stop();
            }
        }

    }
    void Stop() //defines what "pause" is 
    {
        PauseMenuCanvas.SetActive(true); //the pause canvas is active
        Time.timeScale = 0f; //time is paused
        Paused = true; //the game is paused

    }
    public void Play()
    {
        PauseMenuCanvas.SetActive(false); //pause canvas is inactive
        Time.timeScale = 1f; //time is resumed
        Paused = false; //game is not pasued

    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu"); //when the button is pressed it switches the scene to the main menu
        
    }

    public void Settings() //when the settings button is pressed, time is set to 0, the audiopage is set as the default active page, the pause canvas is set inactive
    {
        Time.timeScale = 0f;
        PauseMenuCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
        AudioPage.SetActive(true);

    }

    public void BackToPauseMenu() //provides a way for the player to go back to the pause menu from the settings page.
    {
        Time.timeScale = 0f;
        PauseMenuCanvas.SetActive(true); //sets the pause menu canvas active and deactivates the settings canvas
        SettingsCanvas.SetActive(false);
    }

    
}
