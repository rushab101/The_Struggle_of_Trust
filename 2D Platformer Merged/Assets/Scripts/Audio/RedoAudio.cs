using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedoAudio : MonoBehaviour
{
    private int firstPlayInt;
    public Slider backgroundSlider;
    private float backgroundfloat;
    public AudioSource backgroundAudio;
    private float firstPlay =0f;


    void Awake() {
        firstPlay = PlayerPrefs.GetFloat("FirstPlay");
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundAudio = GetComponent<AudioSource>();
        if (firstPlay == 0.0f)
            firstPlay = 0.5f; 
        backgroundSlider.value = firstPlay; //Setting the slider volume from memory
        backgroundAudio.volume = backgroundSlider.value; //Setting the volume to the slider volume 
       
    }



    public void SaveSoundSettings()
    {

        PlayerPrefs.SetFloat("FirstPlay", backgroundSlider.value);
        PlayerPrefs.Save();

    }
    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
    }

    void Update()
    {
        UpdateSound();
        SaveSoundSettings();
    }
}
