using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SoundMenuInteractions : MonoBehaviour
{
    AudioSource source;
    bool isLooping;
    public GameObject soundMenu;
    private string soundObjectName;
    public Material green;
    public Material red;
    public AudioMixer masterMixer;

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
            foreach (Transform trans in GameObject.Find(whichSoundObjectName).GetComponentInChildren<Transform>())
            {
                if (trans.name == "beveledSurface52")
                {
                    trans.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
                if (trans.name == "beveledSurface53")
                {
                    trans.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
                if (trans.name == "beveledSurface53")
                {
                    trans.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
        else
        {
            source.Play();
            ;
            GameObject speakerPart=GameObject.Find(whichSoundObjectName).transform.Find("Speaker/beveledSurface52").gameObject;
            speakerPart.GetComponent<MeshRenderer>().materials[0].color = Color.green;
            speakerPart.GetComponent<MeshRenderer>().materials[0] = green;
            speakerPart.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            speakerPart.GetComponent<Renderer>().material.SetColor("_TintColor", Color.green);

            //GameObject speakerPart2 = GameObject.Find(whichSoundObjectName).transform.Find("Speaker/beveledSurface53").gameObject;
            //speakerPart2.GetComponent<MeshRenderer>().materials[0].color = Color.green;
            //speakerPart2.GetComponent<Renderer>().material.SetColor("_TintColor", Color.green);

            //speakerPart.GetComponent<Renderer>().material.color = Color.green;
            GameObject speakerPart3 = GameObject.Find(whichSoundObjectName).transform.Find("Speaker/beveledSurface54").gameObject;
            //speakerPart2.GetComponent<MeshRenderer>().materials[0].color = Color.green;
            //speakerPart3.GetComponent<Renderer>().material.SetColor("_TintColor", Color.green);
            //foreach (Transform trans in GameObject.Find(whichSoundObjectName).GetComponentInChildren<Transform>())
            //{
            //    if (trans.name == "Speaker")
            //    {
            //        if (trans.name == "beveledSurface52")
            //        {
            //            trans.gameObject.GetComponent<Renderer>().material.color = Color.green;
            //        }
            //        if (trans.name == "beveledSurface53")
            //        {
            //            trans.gameObject.GetComponent<Renderer>().material.color = Color.green;
            //        }
            //        if (trans.name == "beveledSurface53")
            //        {
            //            trans.gameObject.GetComponent<Renderer>().material.color = Color.green;
            //        }
            //    }
            //}
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
    public void UpdateVolume(float value)
    {
        getAudioSource(soundObjectName);

        foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
        {          
            if (trans.name == "SliderVolume")
            {
                source.volume = trans.gameObject.GetComponent<Slider>().value;
            }
            if (trans.name == "TextVolumeValue")
            {
                trans.gameObject.GetComponent<TextMeshProUGUI>().text = value.ToString("0.00");
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

    public void updateRolloff(int value)
    {
        getAudioSource(soundObjectName);
        if (value==0)
        {
            source.rolloffMode = AudioRolloffMode.Linear;
        }
        if (value == 1)
        {
            source.rolloffMode = AudioRolloffMode.Logarithmic;
        }
        if (value == 2)
        {
            source.rolloffMode = AudioRolloffMode.Custom;
        }
    }

    public void setBGMasterVolume(float value)
    {
        masterMixer.SetFloat("BGMasterVolume", value);
        float output;
        masterMixer.GetFloat("BGMasterVolume", out output);
        Debug.Log("Master Background Volume is:" + output);

    }

    public void setBGMusicVolume(float value)
    {
        masterMixer.SetFloat("BGMusicVolume",value);
    }

    public void setBGChatterVolume(float value)
    {
        masterMixer.SetFloat("BGChatterVolume", value);
    }
    public void setBGAirConVolume(float value)
    {
        masterMixer.SetFloat("BGACVolume", value);
       
    }
}
