using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCanvas : MonoBehaviour
{
    public GameObject GameOverCanvas;

    public Animator anim;
    public Rigidbody2D rb;
    [SerializeField] private AudioSource death;
    public static bool deaths;
    private void Start() //canvas set to false at the start
    {
        deaths = false;
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
        
    }

    public void Deathcanvas() //function called in the animation event of the death animation, so that after the player performs the death animation the gameover screen would appear.
    {
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { //checks for player hp, if it dropped below 0, the player died

        if (collision.gameObject.CompareTag("trap")) //if player health drops below 0, the player dies
        {
            deaths = true;
            die();
            deaths = false;
        }
    }



    public static void Restart() //when the player decides to replay, the time is set back to 1f(normal time), and the GameOver canvas is set inactive
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        

    }
    void die() //death method, player plays the death animation and cannot control the player anymore, as the player is dead.
    {
        if (deaths)
        {
            death.Play();
            anim.Play("HeroKnight_Death");
            rb.bodyType = RigidbodyType2D.Static;
        }
       
    }
}


