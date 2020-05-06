using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ProperAudio : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlayInt;
    public Slider backgroundSlider;
    private float backgroundfloat;

     void start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        UnityEngine.Debug.Log(FirstPlay);
        if (firstPlayInt == 0)
        {
            backgroundfloat = 0.5f;
            backgroundSlider.value = backgroundfloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundfloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundfloat;

        }
    }

   

    public void SaveSoundSettings()
    {

        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        
    }



    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus == false)
        {
            UnityEngine.Debug.Log("message");
            SaveSoundSettings();
        }
    }





}
