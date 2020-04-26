using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InformationTrigger : MonoBehaviour
{
    public GameObject informationCanvas;


    void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.name);
        if(other.name== "[VRTK][AUTOGEN][FootColliderContainer]")
        informationCanvas.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {


        //if (other.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        if (other.name == "[VRTK][AUTOGEN][FootColliderContainer]")
            informationCanvas.SetActive(false);
    }


}
