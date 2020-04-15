using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ChangeRadialMenuIcons : MonoBehaviour
{
    public VRTK_RadialMenu a;
    AudioSource audioSource;
    public Sprite PlaySymbol;
    public Sprite PauseSymbol;

    bool buttonsPlayRegenerated = false;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = this.transform.parent.parent.parent.gameObject.GetComponent<AudioSource>();
        a = this.GetComponent<VRTK_RadialMenu>();
        Debug.Log("Name is: " + audioSource.gameObject.name);
    }
    void Start()
    {

        //Debug.Log("Menu Buttons Count is" + a.menuButtons.Count);

        //for (int i=0; i<a.buttons.Count; i++)
        //{
        //    a.buttons[i].ButtonIcon = PauseSymbol;
        //    a.RegenerateButtons();
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //if(audioSource.isPlaying)
        //{
        //    if(!buttonsPlayRegenerated)
        //    {
        //        for (int i = 0; i < a.buttons.Count; i++)
        //        {
        //            a.buttons[i].ButtonIcon = PauseSymbol;
        //            a.RegenerateButtons();
        //        }
        //        buttonsPlayRegenerated = true;

        //    }
        //}
    }
}
