using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    //canvasMenu.SetActive(false);
                    soundCubeMenu.SetActive(false);
                    activeMenuName = "";
                }
                else
                {
                    canvasMenu.SetActive(false);
                    soundCubeMenu.SetActive(true);
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

}
