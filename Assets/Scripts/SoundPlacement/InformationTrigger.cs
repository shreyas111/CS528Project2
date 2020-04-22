using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InformationTrigger : MonoBehaviour
{
    public GameObject informationCanvas;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter object" + other.name);
        if(other.name=="Head")
        informationCanvas.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit Object" + other.name);
        if (other.name == "Head")
            informationCanvas.SetActive(false);
    }


}
