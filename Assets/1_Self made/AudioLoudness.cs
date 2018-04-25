﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudness : MonoBehaviour
{

    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;
    public Light light;

    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;

    CubeMaker cm;

    // Use this for initialization
    void Awake()
    {

        if (!audioSource)
        {
            Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
        }
        clipSampleData = new float[sampleDataLength];
        cm = GetComponent<CubeMaker>();
    }

    // Update is called once per frame
    void Update()
    {

        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
            cm.y = clipLoudness*30f;
            cm.dis = 1 + clipLoudness;
            light.intensity = 1 + clipLoudness * 2;
            
        }

    }

}
