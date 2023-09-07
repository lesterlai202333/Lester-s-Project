using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LevelSelection(string sceneName) // allows the player to go to a particular scene that it's name is given in unity
    {
        SceneManager.LoadScene(sceneName);
    }

    public void BackToMenu()//lets the player go back to the main menu scene
    {
        SceneManager.LoadScene("MainMenu");
    }
}
