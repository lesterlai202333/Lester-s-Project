using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource finishSound;
    private bool levelcompleted = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelcompleted)
        {
            finishSound.Play();
            levelcompleted = true;
            Invoke("CompleteLevel", 2f);
            
       
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
