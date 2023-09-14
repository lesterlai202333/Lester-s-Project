using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCanvas : MonoBehaviour
{
    public GameObject GameOverCanvas;

    private void Start() //canvas set to false at the start
    {
        GameOverCanvas.SetActive(false);
    }

    public void Deathcanvas() //function called in the animation event of the death animation, so that after the player performs the death animation the gameover screen would appear.
    {
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
