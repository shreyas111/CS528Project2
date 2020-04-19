using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundCubeMenuInteractions : MonoBehaviour
{

    AudioSource source;
    bool isLooping;
    public GameObject soundCubeMenu;
    // Start is called before the first frame update
    void Awake()
    {
        //source= this.GetComponent<AudioSource>();
        //isLooping = source.loop;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void enableDisableMenu()
    //{
    //    Debug.Log("Menu Enabled and disbaled");

    //}
    private void getAudioSource(string objectName)
    {
        source = GameObject.Find(objectName).GetComponent<AudioSource>();
        isLooping = source.loop;
    }
    public void playPause(string objectName)
    {
       
        getAudioSource(objectName);
        if (source.isPlaying)
        {
            source.Pause();
        }
        else
        {
            source.Play();
        }
       
    }
    public void loopUnloop(string objectName)
    {
        getAudioSource(objectName);
        isLooping = !isLooping;
        source.loop = isLooping;
    }
    public void stop(string objectName)
    {
        getAudioSource(objectName);
        if (source.isPlaying)
        {
            source.Stop();
        }
    }
    public void UpdateVolume()
    {
        foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderVolume")
            {
                source.volume=trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updatePitch()
    {
        foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderPitch")
            {
                source.pitch = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updatePriority()
    {
        foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderPitch")
            {
                source.priority = Convert.ToInt32(trans.gameObject.GetComponent<Slider>().value);
            }
        }
    }
    public void updateStereoPan()
    {
        foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderStereoPan")
            {
                source.panStereo = trans.gameObject.GetComponent<Slider>().value;
            }
        }

    }
    public void updateSpatialBlend()
    {
        foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderSpatialBlend")
            {
                source.spatialBlend = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updateReverbMix()
    {
        foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderReverbMix")
            {
                source.reverbZoneMix = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updateDoplerLevel()
    {
        foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderDopplerLevel")
            {
                source.dopplerLevel = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updateSpread()
    {
        foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderSpread")
            {
                source.spread = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updateMinDistance()
    {
        foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderMinDistance")
            {
                source.minDistance = Convert.ToInt32(trans.gameObject.GetComponent<Slider>().value);
            }
        }

    }
    public void updateMaxDistance()
    {
        foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
        {
            //Debug.Log("Distance is Max" + trans.gameObject.GetComponent<Slider>().value);
            if (trans.name == "SliderMaxDistance")
            {
                source.maxDistance = Convert.ToInt32(trans.gameObject.GetComponent<Slider>().value);
            }
        }
    }
}
