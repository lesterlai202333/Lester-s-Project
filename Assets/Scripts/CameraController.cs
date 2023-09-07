using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; //this part here provides a way to access the information of another sprite, the data of this sprite is stored as player.

    // Update is called once per frame
    void Update()
    {//constantly adjusting the position of the camera in relation to the player's transform positions.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
