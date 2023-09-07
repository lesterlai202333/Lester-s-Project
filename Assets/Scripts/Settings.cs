using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GameObject AudioPage;
    public GameObject GameplayPage;
    public GameObject GraphicsPage;
    
    public GameObject PlayercontrolPage; //declares the variables, and in unity editor, there will be fields that I can assign these variables to the actual gameobjects therefore acquiring their data
    void Start()
    {
        //useless
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AudioPageOn()//this function sets the audio page active and all the other inactive.
    {
        AudioPage.SetActive(true);
        GameplayPage.SetActive(false);
        GraphicsPage.SetActive(false);
        PlayercontrolPage.SetActive(false);

    }

    public void GameplayPageOn()//this function sets the Gameplay active and all the other inactive.
    {
        AudioPage.SetActive(false);
        GameplayPage.SetActive(true);
        GraphicsPage.SetActive(false);
        PlayercontrolPage.SetActive(false);

    }

    public void GraphicsPageOn()//this function sets the graphics page active and all the other inactive.
    {
        AudioPage.SetActive(false);
        GameplayPage.SetActive(false);
        GraphicsPage.SetActive(true);
        PlayercontrolPage.SetActive(false);

    }

    public void PlayercontrolPageOn() //this function sets the player control page active, and all the other pages inactive.
    {
        AudioPage.SetActive(false);
        GameplayPage.SetActive(false);
        GraphicsPage.SetActive(false);
        PlayercontrolPage.SetActive(true);

    }

}
