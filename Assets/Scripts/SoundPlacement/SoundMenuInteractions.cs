using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using VRTK;

public class SoundMenuInteractions : MonoBehaviour
{
    AudioSource source;
    bool isLooping;
    public GameObject soundMenu;
    public string soundObjectName;
    public Material green;
    public Material red;
    public AudioMixer masterMixer;


    //For Changing Radial Menu Symbols.
    private GameObject panel;
    public Sprite PlaySymbol;
    public Sprite PauseSymbol;



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
        panel = GameObject.Find(objectName).transform.Find("RadialMenu1/RadialMenuUI/Panel").gameObject;        
        isLooping = source.loop;
    }
    public void playPause(string whichSoundObjectName)
    {

        getAudioSource(whichSoundObjectName);
        if (source.isPlaying)
        {
            source.Pause();
            panel.GetComponent<VRTK_RadialMenu>().buttons[1].ButtonIcon = PlaySymbol;
            panel.GetComponent<VRTK_RadialMenu>().RegenerateButtons();

            //foreach (Transform trans in GameObject.Find(whichSoundObjectName).GetComponentInChildren<Transform>())
            //{
            //    if (trans.name == "Sphere")
            //    {
            //        MeshRenderer sphereRenderer = trans.gameObject.GetComponent<MeshRenderer>();
            //        sphereRenderer.material = red;
            //    }
            //}
        }
        else
        {
            source.Play();
            panel.GetComponent<VRTK_RadialMenu>().buttons[1].ButtonIcon = PauseSymbol ;
            panel.GetComponent<VRTK_RadialMenu>().RegenerateButtons();

            //GameObject marker = GameObject.Find(whichSoundObjectName).transform.Find("Sphere").gameObject;

            //marker.GetComponent<MeshRenderer>().materials[0].color = Color.green;
            //marker.GetComponent<MeshRenderer>().material.color = Color.green;
            //marker.GetComponent<Renderer>().material = green;
            //speakerPart.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            //speakerPart.GetComponent<Renderer>().material.SetColor("_TintColor", Color.green);

            //GameObject speakerPart2 = GameObject.Find(whichSoundObjectName).transform.Find("Speaker/beveledSurface53").gameObject;
            //speakerPart2.GetComponent<MeshRenderer>().materials[0].color = Color.green;
            //speakerPart2.GetComponent<Renderer>().material.SetColor("_TintColor", Color.green);

            //speakerPart.GetComponent<Renderer>().material.color = Color.green;
            //GameObject speakerPart3 = GameObject.Find(whichSoundObjectName).transform.Find("Speaker/beveledSurface54").gameObject;
            //speakerPart2.GetComponent<MeshRenderer>().materials[0].color = Color.green;
            //speakerPart3.GetComponent<Renderer>().material.SetColor("_TintColor", Color.green);
            //foreach (Transform trans in GameObject.Find(whichSoundObjectName).GetComponentInChildren<Transform>())
            //{
            //    if (trans.name == "Sphere")
            //    {
            //        MeshRenderer sphereRenderer = trans.gameObject.GetComponent<MeshRenderer>();
            //        sphereRenderer.material = green;

            //        //Material[] mat = sphereRenderer.materials;
            //        //Debug.Log("Size of Materials is" + mat.Length);
            //        //Debug.Log("Size of Materials 0 is" + mat[0].name);
            //        //Debug.Log("Size of Materials 1 is" + mat[1].name);
            //        //Material[] newMaterials = new Material[] { green };
            //        //sphereRenderer.materials = newMaterials;
            //        //sphereRenderer.enabled = true;                
            //        //sphereRenderer.material = green;
            //    }
            //}
            //foreach (Transform trans in GameObject.Find(whichSoundObjectName).GetComponentInChildren<Transform>())
            //{
            //    if (trans.name == "Speaker")
            //    {
            //        foreach (Transform trans1 in trans.gameObject.GetComponentInChildren<Transform>())
            //        {
            //            if (trans.name == "beveledSurface52")
            //            {
            //                MeshRenderer sphereRenderer = trans1.gameObject.GetComponent<MeshRenderer>();
            //                sphereRenderer.material = green;
            //            }
            //            if (trans.name == "beveledSurface53")
            //            {
            //                MeshRenderer sphereRenderer = trans1.gameObject.GetComponent<MeshRenderer>();
            //                sphereRenderer.material = green;
            //            }
            //            if (trans.name == "beveledSurface54")
            //            {
            //                MeshRenderer sphereRenderer = trans1.gameObject.GetComponent<MeshRenderer>();
            //                sphereRenderer.material = green;
            //            }
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
            panel.GetComponent<VRTK_RadialMenu>().buttons[1].ButtonIcon = PlaySymbol;
            panel.GetComponent<VRTK_RadialMenu>().RegenerateButtons();
            //foreach (Transform trans in GameObject.Find(whichSoundObjectName).GetComponentInChildren<Transform>())
            //{
            //    if (trans.name == "Sphere")
            //    {
            //        MeshRenderer sphereRenderer = trans.gameObject.GetComponent<MeshRenderer>();
            //        sphereRenderer.material = red;
            //    }
            //}

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
        if (value == 0)
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
        masterMixer.SetFloat("BGMusicVolume", value);
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
