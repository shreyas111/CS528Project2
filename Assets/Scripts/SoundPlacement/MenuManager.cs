using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject soundCubeMenu;    
    public string activeMenuName;

    private void Awake()
    {
        activeMenuName = "";
    }

    public void activateDeactivateMenus(string menuName)
    {
      
        switch (menuName)
        {

            case "SoundCubeMenu":
                Debug.Log("MenuName is" + menuName);
                if(activeMenuName.Equals("SoundCubeMenu"))
                {
                    
                    soundCubeMenu.SetActive(false);
                    activeMenuName = "";
                }
                else
                {
                    canvasMenu.SetActive(false);
                    soundCubeMenu.SetActive(true);
                    setMenuValues("SoundCubeMenu");

                    activeMenuName = "SoundCubeMenu";
                }
                break;
            case "CanvasMenu":
                Debug.Log("MenuName is" + menuName);
                if (activeMenuName.Equals("CanvasMenu"))
                {
                    canvasMenu.SetActive(false);
                    activeMenuName = "";

                }
                else
                {
                    soundCubeMenu.SetActive(false);
                    canvasMenu.SetActive(true);                    
                    activeMenuName = "CanvasMenu";
                }
                break;

        }
    }
    public void setMenuValues(string menuName)
    {
        switch (menuName)
        {
            case "SoundCubeMenu":
                AudioSource soundCube = GameObject.Find("SoundCube").GetComponent<AudioSource>();
                foreach (Transform trans in soundCubeMenu.GetComponentInChildren<Transform>())
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
                }
                        
                break;
            case "CanvasMenu":
                break;
        }
    }
}
