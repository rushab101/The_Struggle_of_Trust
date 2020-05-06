using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScript : MonoBehaviour
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
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        UnityEngine.Debug.Log(FirstPlay);
        if (firstPlayInt == 0)
        {
            backgroundfloat = 0.75f;
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
            // UnityEngine.Debug.Log("message");
            SaveSoundSettings();
        }
    }



    public void UpdateSound()
    {
         UnityEngine.Debug.Log("message");
        backgroundAudio.volume = backgroundSlider.value;
    }


}
