using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMenuInteractions : MonoBehaviour
{
    AudioSource source;
    bool isLooping;
    public GameObject soundMenu;
    private string soundObjectName;

    public string SoundObjectName
    {
        get
        {
            return soundObjectName;
        }
        set
        {
            soundObjectName = value;
        }
    }

    public void enableDisableMenu()
    {
        Debug.Log("Menu Enabled and disbaled");

    }
    private void getAudioSource(string objectName)
    {
        source = GameObject.Find(objectName).GetComponent<AudioSource>();
        isLooping = source.loop;
    }
    public void playPause(string whichSoundObjectName)
    {

        getAudioSource(whichSoundObjectName);
        if (source.isPlaying)
        {
            source.Pause();
        }
        else
        {
            source.Play();
        }

    }
    public void loopUnloop(string whichSoundObjectName)
    {
        getAudioSource(whichSoundObjectName);
        isLooping = !isLooping;
        source.loop = isLooping;
    }
    public void stop(string whichSoundObjectName)
    {
        getAudioSource(whichSoundObjectName);
        if (source.isPlaying)
        {
            source.Stop();
        }
    }
    public void UpdateVolume()
    {
        getAudioSource(soundObjectName);

        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {          
            if (trans.name == "SliderVolume")
            {
                source.volume = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updatePitch(string objectName)
    {
        getAudioSource(soundObjectName);
        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderPitch")
            {
                source.pitch = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updatePriority(string objectName)
    {
        getAudioSource(soundObjectName);
        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderPitch")
            {
                source.priority = Convert.ToInt32(trans.gameObject.GetComponent<Slider>().value);
            }
        }
    }
    public void updateStereoPan(string objectName)
    {
        getAudioSource(soundObjectName);
        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderStereoPan")
            {
                source.panStereo = trans.gameObject.GetComponent<Slider>().value;
            }
        }

    }
    public void updateSpatialBlend(string objectName)
    {
        getAudioSource(soundObjectName);
        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderSpatialBlend")
            {
                source.spatialBlend = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updateReverbMix(string objectName)
    {
        getAudioSource(soundObjectName);
        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderReverbMix")
            {
                source.reverbZoneMix = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updateDoplerLevel(string objectName)
    {
        getAudioSource(soundObjectName);
        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderDopplerLevel")
            {
                source.dopplerLevel = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updateSpread(string objectName)
    {
        getAudioSource(soundObjectName);
        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderSpread")
            {
                source.spread = trans.gameObject.GetComponent<Slider>().value;
            }
        }
    }
    public void updateMinDistance(string objectName)
    {
        getAudioSource(soundObjectName);
        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderMinDistance")
            {
                source.minDistance = Convert.ToInt32(trans.gameObject.GetComponent<Slider>().value);
            }
        }

    }
    public void updateMaxDistance(string objectName)
    {
        getAudioSource(soundObjectName);
        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {
            //Debug.Log("Distance is Max" + trans.gameObject.GetComponent<Slider>().value);
            if (trans.name == "SliderMaxDistance")
            {
                source.maxDistance = Convert.ToInt32(trans.gameObject.GetComponent<Slider>().value);
            }
        }
    }
}
