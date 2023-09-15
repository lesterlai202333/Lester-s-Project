using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private AudioSource buttonsounds;
    public void LevelSelection(string sceneName) // allows the player to go to a particular scene that it's name is given in unity
    {
        buttonsounds.Play();//plays sound effect
        SceneManager.LoadScene(sceneName);
    }

    public void BackToMenu()//lets the player go back to the main menu scene
    {
        buttonsounds.Play();//plays sound effect
        SceneManager.LoadScene("MainMenu");
    }
}
