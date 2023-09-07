using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float distance;

    GameObject[] backgrounds;
    Material[] mat; // the [] indicates that it's an array of materal. In this context is here to store multiple material objects so that they can be accessed individually, therefore possible for multiple parallax scrolling backgrounds
    float[] backSpeed;

    float farthestBack; 

    [Range(0.001f, 0.01f)]
    public float parallaxSpeed; //variables are being declared, a range is given to the parallax speed value
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform; //sets the cam value to the transform of the camera
        camStartPos = cam.position; //sets the starting position of the camera to the cam position defined above

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];
        //backcount stores the number of child objects under the current gameobject, mat now stores a new array that has a length of the backcount, backspeed is set to a new array that has its length based on backcount. backgrounds is set to an array that stores a number of gameobjects(length=backcount)
        for (int i=0; i<backCount; i ++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;//It gets the i-th child object of the current GameObject and stores it in the backgrounds array at index i. 
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;//it gets the i-th Render component information of the i-th background

        }
        BackSpeedCalculate(backCount);
    }

    // Update is called once per frame
    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++) //initializes i to 0, the condition is i < backcount, and that i increases by 1 each time
        {
            if ((backgrounds[i].transform.position.z - cam.position.z ) > farthestBack) //calculates the difference in z value between the i-th background layer and the camera, if it is larger than the farthestBack value it replaces the farthest back value
            { 
                farthestBack = -(backgrounds[i].transform.position.z - cam.position.z);
            }
        }
        for (int i = 0; i < backCount; i++)//initializes i to 0, the condition is i < backcount, and that i increases by 1 each time
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack; //the left side of the equal sign calculates a value that is assigned to the backspeed array of the i-th index, it determines how fast the i-th background moves
        }//so it adjusts the backspeed based on its distance from the camera, crucial for the parallax scrolling.
    }


    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x; //calculates the horizontal distance that the camera has moved since the start of the scene
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);//This line updates the position of the GameObject that holds the backgrounds. It follows the horizontal movement of the camera to ensure that the backgrounds remain aligned with the camera's x position while keeping their y and z positions unchanged.
        for (int i = 0; i < backgrounds.Length; i++) //initiates a loop, i is set to 0, i is lower than the backgrounds-length(condition), and that i += 1 each time
        {
            float speed = backSpeed[i] * parallaxSpeed;//for each background layer its speed is calculated
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);//this line sets the texture offset of the i-th background. It shifts the texture horizontally based on the distance calculated and the speed calculated above. Which creates the parallax scrolling effect, where backgrounds move at different speeds relative to the camera.
        }
    }
}
