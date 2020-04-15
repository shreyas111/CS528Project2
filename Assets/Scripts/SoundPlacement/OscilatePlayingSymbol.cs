using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilatePlayingSymbol : MonoBehaviour
{
    Vector3 originalScale;
    float startRange;
    float endRange;
    float oscilationRange;
    float oscilationOffset;

    public Material green;
    public Material red;

    AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = this.transform.parent.gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        originalScale = this.transform.localScale;
 

        startRange = originalScale.x - (originalScale.x * 0.1f);



        endRange = originalScale.x;


        oscilationRange = (endRange - startRange) / 2;


        oscilationOffset = oscilationRange + startRange;
  
    }

    // Update is called once per frame
    void Update()
    {

   
        if (audioSource.loop && audioSource.isPlaying)
        {
            Oscilate();            
        }
        if(audioSource.isPlaying)
        {
            MeshRenderer sphereRenderer = this.gameObject.GetComponent<MeshRenderer>();
            sphereRenderer.material = green;
        }
        else
        {
            MeshRenderer sphereRenderer = this.gameObject.GetComponent<MeshRenderer>();
            sphereRenderer.material = red;

        }
    }

    private void Oscilate()
    {
        float newScaleValue;
        newScaleValue = oscilationOffset + Mathf.Sin(Time.time * 4) * oscilationRange;
        //Debug.Log("New Scale Value is" + newScaleValue);
        Vector3 newScale = new Vector3(newScaleValue, newScaleValue, newScaleValue);
        this.transform.localScale = newScale;
    }
}

