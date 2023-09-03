using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuIcons : MonoBehaviour
{
    public GameObject Mute;
    public GameObject SoundOn;
    // Start is called before the first frame update
    void Start()
    {
        Unmute();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void Muted ()
    {
        Mute.SetActive(true);
        SoundOn.SetActive(false);
    }


    public void Unmute()
    {
        Mute.SetActive(false);
        SoundOn.SetActive(true); 
    }
}
