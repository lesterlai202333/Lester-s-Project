using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //has to be included if you want to switch between scenes

public class GameOver : MonoBehaviour
{
   
    public GameObject GameOverCanvas;

    void Start() //when the game starts, the time is set to normal(1)
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    { //checks for player hp, if it dropped below 0, the player died
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (InGamePauseMenu.Paused)//an example usage of a static bool
            {
                Play();
            }
            else
            {
                Stop();
            }
        }

    }
    void Stop() //when the game is over, the time is set to 0, and the game over canvas is set to true so that it shows, 
    {
        GameOverCanvas.SetActive(true); 
        Time.timeScale = 0f;
        InGamePauseMenu.Paused = true; //static bool usage, we are accessing the boolean value from another script and changing it

    }
    public void Play() //when the player decides to replay, the time is set back to 1f(normal time), and the GameOver canvas is set inactive
    {
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1f; 
        InGamePauseMenu.Paused = false; //static bool usage, we are accessing the boolean value from another script and changing i

    }

    public void BackToMenu() //sends the player back to the main menu scene.
    {
        SceneManager.LoadScene("MainMenu");

    }
}
