﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilatePlayingObject : MonoBehaviour
{
    Vector3 originalScale;
    float startRange;
    float endRange;
    float oscilationRange;
    float oscilationOffset;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = this.transform.localScale;
        Debug.Log("OriginalScale is" + originalScale);

        startRange = originalScale.x - (originalScale.x * 0.1f);
        //startRange = originalScale.x;

        Debug.Log("Start Range is" + startRange);
        //endRange = originalScale.x + (originalScale.x * 0.4f);
        endRange = originalScale.x;

        Debug.Log("End Range is" + endRange);
        oscilationRange = (endRange - startRange) / 2;

        Debug.Log("Oscilation Range is" + oscilationRange);

        oscilationOffset = oscilationRange + startRange;
        Debug.Log("Oscilation Offset is" + oscilationOffset);
    }

    // Update is called once per frame
    void Update()
    {

        audioSource = this.GetComponent<AudioSource>();
        if (audioSource.isPlaying)
        {
            Oscilate();
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
