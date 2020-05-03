using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderVolume : MonoBehaviour
{
    private AudioSource AudioSrc;

    private float AudioVolume = 1f;

    void Start()
    {
        AudioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        AudioSrc.volume = AudioVolume;
    }

    public void SetVolume(float vol)
    {
        AudioVolume = vol;
    }
}
