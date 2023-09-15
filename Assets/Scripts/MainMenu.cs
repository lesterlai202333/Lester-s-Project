using UnityEngine;
using UnityEngine.SceneManagement; //this has to be included if you wanna switch between scenes

public class MainMenu : MonoBehaviour
{
   public void GoToScene(string sceneName) { button.Play(); SceneManager.LoadScene(sceneName); } // this allows the player to go to a specific scene which its name is defined by the develope sr inside unity(level selection page)
    public GameObject SettingsCanvas;
    [SerializeField] private AudioSource settingsnoise; //declaring the audiosource to be used
    [SerializeField] private AudioSource button;

    public void QuitApp() //The player quits the game, line 10 wouldn't work when testing in unity, line 11 is here to show that this piece of code works.
    {
        button.Play();
        Application.Quit();
        Debug.Log("Application has quit");
    }

    public void ExitSettings() //when the button is clicked, the settings canvas is set inactive so it disappears
    {
        settingsnoise.Play();//plays the sound effect
        SettingsCanvas.SetActive(false);
    }

    public void EnterSettings()//when the button is clicked, the settings Canvas is set active/
    {
        settingsnoise.Play(); //plays the sound effect
        SettingsCanvas.SetActive(true);

    }
}
