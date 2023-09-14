using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //has to be included if you want to switch between scenes

public class GameOver : MonoBehaviour
{
    public static bool dead;
    
    public Animator anim;
    public Rigidbody2D rb;

    void Start() //when the game starts, the time is set to normal(1)
    {

        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    { //checks for player hp, if it dropped below 0, the player died

        if (HealthManager.playerHealth <= 0) //if player health drops below 0, the player dies
        {

            die();

        }
    }
   
    public static void Restart() //when the player decides to replay, the time is set back to 1f(normal time), and the GameOver canvas is set inactive
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        dead = false;
        HealthManager.playerHealth = 100;

    }
    void die() //death method, player plays the death animation and cannot control the player anymore, as the player is dead.
    {
        anim.Play("HeroKnight_Death");
        rb.bodyType = RigidbodyType2D.Static;
    }

}
