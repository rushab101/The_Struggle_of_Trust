using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private float backgroundfloat;
    public AudioSource backgroundAudio;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.Save();
        ContinueSettings();
    }

    private void ContinueSettings()
    {

        backgroundfloat = PlayerPrefs.GetFloat(BackgroundPref);
//        UnityEngine.Debug.Log(backgroundfloat);
        backgroundAudio.volume = backgroundfloat;

    }


}
