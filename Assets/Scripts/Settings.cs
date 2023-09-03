using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GameObject AudioPage;
    public GameObject GameplayPage;
    public GameObject GraphicsPage;
    public GameObject PlayercontrolPage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AudioPageOn()
    {
        AudioPage.SetActive(true);
        GameplayPage.SetActive(false);
        GraphicsPage.SetActive(false);
        PlayercontrolPage.SetActive(false);

    }

    public void GameplayPageOn()
    {
        AudioPage.SetActive(false);
        GameplayPage.SetActive(true);
        GraphicsPage.SetActive(false);
        PlayercontrolPage.SetActive(false);

    }

    public void GraphicsPageOn()
    {
        AudioPage.SetActive(false);
        GameplayPage.SetActive(false);
        GraphicsPage.SetActive(true);
        PlayercontrolPage.SetActive(false);

    }

    public void PlayercontrolPageOn()
    {
        AudioPage.SetActive(false);
        GameplayPage.SetActive(false);
        GraphicsPage.SetActive(false);
        PlayercontrolPage.SetActive(true);

    }

}
