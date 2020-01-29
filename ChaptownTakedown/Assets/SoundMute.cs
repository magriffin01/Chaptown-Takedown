using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMute : MonoBehaviour
{
    public AudioSource audioSource;

    bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClick()
    {
        if(clicked == false)
        {
            audioSource.volume = 0;
            clicked = true;
        }
        else if (clicked == true)
        {
            audioSource.volume = 1;
            clicked = false;
        }

    }
}
