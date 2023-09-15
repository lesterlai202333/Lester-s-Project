using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ItemCollector : MonoBehaviour
{
    private int kiwi = 0;
    [SerializeField] public TextMeshProUGUI score;
    [SerializeField] private AudioSource soundeffect; //declaring variables

    private void OnTriggerEnter2D(Collider2D collision) //checks for a collider that collides with the trigger collider that this script is attached to(the player)
    {
        if (collision.gameObject.CompareTag("Kiwi")) //if the collided object has a tag named Kiwi, then the sound effect is played first, the kiwi is destroyed, and that the score of the player increases by one
            {
            soundeffect.Play();
            Destroy(collision.gameObject);
            kiwi++;
            score.text = "Score:" + kiwi;
        }

    }
}
