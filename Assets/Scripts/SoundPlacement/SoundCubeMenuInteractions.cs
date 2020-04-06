using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCubeMenuInteractions : MonoBehaviour
{

    AudioSource source;
    bool isLooped;
    // Start is called before the first frame update
    void Awake()
    {
        source= this.GetComponent<AudioSource>();
        isLooped = source.loop;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableDisableMenu()
    {
        Debug.Log("Menu Enabled and disbaled");

    }
    public void playPause()
    {
        Debug.Log("Inside Play Pause");

        if(source.isPlaying)
        {
            source.Pause();
        }
        else
        {
            source.Play();
        }

        

    }
    public void loopUnloop()
    {
        source.loop = isLooped;
    }
}
