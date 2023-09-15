using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision) // this function is called when a 2d collider collides with the trigger collider that this script is attached to
    {
        if (collision.gameObject.name == "Player") //if the object collided is named Player, then it sets the player as a child of this platform so that it sticks to it
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //when a GameObject with a Collider2D component exits the trigger collider of the gameobject that this script is attached to.
    {
        if (collision.gameObject.name == "Player") //if the object named Player leaves the trigger collider, then it's set back to not being a child of this platform
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}


