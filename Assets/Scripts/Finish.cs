using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //has to be used with scene transition associated scripts.
public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource finishSound;
    private bool levelcompleted = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>(); //accesses the component audiosource
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) //checks for a collision 
    {
        if(collision.gameObject.name == "Player" && !levelcompleted) //if the collided object has the name player and that the level isn't completed
        {
            finishSound.Play(); //the sound effect is played first, the levelcompleted bool is set to true, and the completelevel method will be called 2 seconds later
            levelcompleted = true;
            Invoke("CompleteLevel", 2f);
            
       
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads the next scene(level)
    }
}
