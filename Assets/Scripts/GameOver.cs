using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject GameOverCanvas;

    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
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
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;

    }
    public void Play()
    {
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1f; 
        Paused = false;

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
