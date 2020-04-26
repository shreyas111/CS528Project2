using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarExhibitTrigger : MonoBehaviour
{
    public GameObject MusicExhibitMic;
    AudioSource source;
    void Awake()
    {
        source = MusicExhibitMic.GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.name);
        if (other.name == "[VRTK][AUTOGEN][FootColliderContainer]")
            source.Play();

    }
    void OnTriggerExit(Collider other)
    {


        //if (other.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        //if (other.name == "[VRTK][AUTOGEN][FootColliderContainer]")

    }
}
