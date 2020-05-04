using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedoAudio : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlayInt;
    public Slider backgroundSlider;
    private float backgroundfloat;
    public AudioSource backgroundAudio;


    // Start is called before the first frame update
    void Start()
    {
        backgroundAudio = GetComponent<AudioSource>();
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        UnityEngine.Debug.Log(FirstPlay);


        //Build Mode



        //-----------------------------------Disable these lines of Code in Debug Mode--------------------------///
        /*
        backgroundfloat = PlayerPrefs.GetFloat(BackgroundPref);
        backgroundSlider.value = backgroundfloat;
        */
        //-----------------------------------Disable these lines of Code in Debug Mode--------------------------///

        backgroundfloat = PlayerPrefs.GetFloat(BackgroundPref);
        backgroundSlider.value = backgroundfloat;

        //-----------------------------------Disable these lines of Code in Build Mode--------------------------///
        /*
        if (firstPlayInt == 0)
        {
            backgroundfloat = 0.5f;
            backgroundSlider.value = backgroundfloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
            PlayerPrefs.Save();
        }
        else
        {
            backgroundfloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundfloat;

        }
        */
        //-----------------------------------Disable these lines of Code in Build Mode--------------------------///

        //  PlayerPrefs.Save();
    }



    public void SaveSoundSettings()
    {

        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.Save();

    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus == false)
        {
            // UnityEngine.Debug.Log("message");
            SaveSoundSettings();
        }
    }
    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
    }

    void Update()
    {
        UpdateSound();
        SaveSoundSettings();
        //  PlayerPrefs.Save();
    }



    public void SetVolume(float vol)
    {
        backgroundAudio.volume = backgroundSlider.value;
    }




}
