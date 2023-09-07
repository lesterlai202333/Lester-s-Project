 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material mat; //declaring a component
    float distance; //declaring variables

    [Range(0f, 0.5f)]
    public float speed = 0.2f; //gives the variable 'speed' a range

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material; //accesses the component Renderer
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * speed; //keeps tract of how far the background has moved, it essentially updates the distance variable by adding it to the change in speed in seconds times the parallax speed already defined before
        mat.SetTextureOffset("_MainTex", Vector2.right * distance); //"_mainTex is a texture. (vector 2.right X distance) means that the background in the render moves horizontally the distance set in the line above
    }
}
