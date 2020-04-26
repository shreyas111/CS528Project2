using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject soundMenu;
    public GameObject audioMixerMenu;
    string activeMenuName;
    string activeObjectName;
    SoundMenuInteractions soundMenuInteractionsScript;
    public AudioMixer masterMixer;

    private void Awake()
    {
        activeMenuName = "";
        activeObjectName = "";
        soundMenuInteractionsScript = this.GetComponent<SoundMenuInteractions>();
        //Debug.Log("Sound Menu Interaction Script is " + soundMenuInteractionsScript);
    }

    public void activateDeactivateMenus(string parameters)
    {
        string[] splitArray = parameters.Split(new Char[] { ',' });
        string menuName = splitArray[0];
        string objectName = splitArray[1];

        //Debug.Log("Menu Name is: " + menuName);
        //Debug.Log("Object Name is: " + objectName);

        switch (menuName)
        {

            case "SoundMenu":

                if(activeMenuName.Equals("SoundMenu"))
                {
                    if (activeObjectName != objectName)
                    {
                        canvasMenu.SetActive(false);
                        audioMixerMenu.SetActive(false);
                        soundMenu.SetActive(true);
                        soundMenuInteractionsScript.SoundObjectName = objectName;

                        setMenuValues("SoundMenu");
                        activeMenuName = "SoundMenu";
                        activeObjectName = objectName;
                    }
                    else
                    {
                        soundMenu.SetActive(false);
                        soundMenuInteractionsScript.SoundObjectName = "";

                        activeMenuName = "";
                        activeObjectName = "";
                    }
                }
                else
                {
                    canvasMenu.SetActive(false);
                    audioMixerMenu.SetActive(false);
                    soundMenu.SetActive(true);
                    soundMenuInteractionsScript.SoundObjectName = objectName;

                    setMenuValues("SoundMenu");
                    activeMenuName = "SoundMenu";
                    activeObjectName = objectName;
                }
                break;
            case "CanvasMenu":
                Debug.Log("MenuName is" + menuName);
                if (activeMenuName.Equals("CanvasMenu"))
                {
                    canvasMenu.SetActive(false);
                    soundMenuInteractionsScript.SoundObjectName = "";
                    activeMenuName = "";
                    activeObjectName = "";

                }
                else
                {
                    soundMenu.SetActive(false);
                    audioMixerMenu.SetActive(false);
                    canvasMenu.SetActive(true);
                    soundMenuInteractionsScript.SoundObjectName = "";
                    activeMenuName = "CanvasMenu";
                    activeObjectName = "";
                }
                break;
            case "AudioMixerMenu":
                if (activeMenuName.Equals("AudioMixerMenu"))
                {
                        audioMixerMenu.SetActive(false);
                        soundMenuInteractionsScript.SoundObjectName = "";
                        activeMenuName = "";
                        activeObjectName = "";
                }
                else
                {
                    soundMenu.SetActive(false);
                    canvasMenu.SetActive(false);
                    audioMixerMenu.SetActive(true);
                    soundMenuInteractionsScript.SoundObjectName = "";
                    activeMenuName = "AudioMixerMenu";
                    setAudioMixerMenuValues();
                    activeObjectName = "";
                }
                break;

        }
    }
    public void setAudioMixerMenuValues()
    {
        foreach (Transform trans in audioMixerMenu.GetComponentInChildren<Transform>())
        {
            if (trans.name == "SliderMaster")
            {
                float output;
                masterMixer.GetFloat("BGMasterVolume", out output);
                trans.gameObject.GetComponent<Slider>().value = output;                

            }
            if (trans.name == "SliderBGMusic")
            {
                float output;
                masterMixer.GetFloat("BGMusicolume", out output);
                trans.gameObject.GetComponent<Slider>().value = output;

            }
            if (trans.name == "SliderBGChatter")
            {
                float output;
                masterMixer.GetFloat("BGChatterVolume", out output);
                trans.gameObject.GetComponent<Slider>().value = output;

            }
            if (trans.name == "SliderBGAirCon")
            {
                float output;
                masterMixer.GetFloat("BGAColume", out output);
                trans.gameObject.GetComponent<Slider>().value = output;

            }
        }
    }
    public void setMenuValues(string menuName)
    {
        switch (menuName)
        {
            case "SoundMenu":
                AudioSource soundCube = GameObject.Find(soundMenuInteractionsScript.SoundObjectName).GetComponent<AudioSource>();
                Debug.Log("Sound Object Name is" + soundMenuInteractionsScript.SoundObjectName);
                foreach (Transform trans in soundMenu.GetComponentInChildren<Transform>())
                {
                    if (trans.name == "SliderVolume")
                    {
                        trans.gameObject.GetComponent<Slider>().value = soundCube.volume;
                    }
                    if (trans.name == "SliderPitch")
                    {
                        trans.gameObject.GetComponent<Slider>().value = soundCube.pitch;
                    }
                    if (trans.name == "SliderPriority")
                    {
                        trans.gameObject.GetComponent<Slider>().value = soundCube.priority;
                    }
                    if (trans.name == "SliderStereoPan")
                    {
                        trans.gameObject.GetComponent<Slider>().value = soundCube.panStereo;
                    }
                    if (trans.name == "SliderSpatialBlend")
                    {
                        trans.gameObject.GetComponent<Slider>().value = soundCube.spatialBlend;
                    }
                    if (trans.name == "SliderReverbMix")
                    {
                        trans.gameObject.GetComponent<Slider>().value = soundCube.reverbZoneMix;
                    }
                    if (trans.name == "SliderDopplerLevel")
                    {
                        trans.gameObject.GetComponent<Slider>().value = soundCube.dopplerLevel;
                    }
                    if (trans.name == "SliderSpread")
                    {
                        trans.gameObject.GetComponent<Slider>().value = soundCube.spread;
                    }
                    if (trans.name == "SliderMinDistance")
                    {
                        trans.gameObject.GetComponent<Slider>().value = soundCube.minDistance;
                    }
                    if (trans.name == "SliderMaxDistance")
                    {
                        trans.gameObject.GetComponent<Slider>().value = soundCube.maxDistance;
                    }
                    if (trans.name == "TextName")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundMenuInteractionsScript.SoundObjectName;
                    }
                    if (trans.name == "TextVolumeValue")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundCube.volume.ToString("0.00");
                    }
                    if (trans.name == "TextPriorityValue")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundCube.priority.ToString();
                    }
                    if (trans.name == "TextPitchValue")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundCube.pitch.ToString("0.00");
                    }
                    if (trans.name == "TextStereoPanValue")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundCube.panStereo.ToString("0.00");
                    }
                    if (trans.name == "TextSpatialBlendValue")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundCube.spatialBlend.ToString("0.00");
                    }
                    if (trans.name == "TextReverbMixValue")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundCube.reverbZoneMix.ToString("0.00");
                    }
                    if (trans.name == "TextDopplerLevelValue")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundCube.dopplerLevel.ToString("0.00");
                    }
                    if (trans.name == "TextSpreadValue")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundCube.spread.ToString(); 
                    }
                    if (trans.name == "TextMinDistanceValue")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundCube.minDistance.ToString("0.00");
                    }
                    if (trans.name == "TextMaxDistanceValue")
                    {
                        trans.gameObject.GetComponent<TextMeshProUGUI>().text = soundCube.maxDistance.ToString("0.00");
                    }
                    if (trans.name == "Dropdown")
                    {
                        if (soundCube.rolloffMode == AudioRolloffMode.Linear)
                        {
                            trans.gameObject.GetComponent<TMP_Dropdown>().value = 0;
                        }
                        if (soundCube.rolloffMode == AudioRolloffMode.Logarithmic)
                        {
                            trans.gameObject.GetComponent<TMP_Dropdown>().value = 1;
                        }
                        if (soundCube.rolloffMode == AudioRolloffMode.Custom)
                        {
                            trans.gameObject.GetComponent<TMP_Dropdown>().value = 2;
                        }
                    }
                }
                        
                break;
            case "CanvasMenu":
                break;
        }
    }
}
