using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;//array declared and set as serializefieldso I can add gameobjects into it
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f; //declaring variables
    private void Update()
    {
        if (Vector3.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) <= 0.1f) //calculates the distance between the platform and the current active waypoint
        {
            currentWaypointIndex++;//the index increases by 1
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; //if the index is larger or equal than the number of gameobjects in the array, then it's reset to 0
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); //makes the platform move towards the waypoints
    } 
}
