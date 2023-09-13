using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //has to be included if you want to switch between scenes

public class GameOver : MonoBehaviour
{
    public static bool dead;
    public GameObject GameOverCanvas;
    public Animator anim;
    public Rigidbody2D rb;

    void Start() //when the game starts, the time is set to normal(1)
    {

        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    { //checks for player hp, if it dropped below 0, the player died
        

    }
    private void Gameover() //after the player dies, the scene is reset
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOverCanvas.SetActive(true);
        GameOver.dead = true;
        Time.timeScale = 0f;
        InGamePauseMenu.Paused = true; //static bool usage, we are accessing the boolean value from another script and changing it
    }
    public static void Restart() //when the player decides to replay, the time is set back to 1f(normal time), and the GameOver canvas is set inactive
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        dead = false;
        HealthManager.playerHealth = 100;

    }
   
}
