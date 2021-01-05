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
    public float firstPlay =0f;
    public float secondPlay;
    public int first_time_run = 0;

    void Awake() {
        firstPlay = PlayerPrefs.GetFloat("FirstPlay");
        first_time_run = PlayerPrefs.GetInt("First_run");

    }

    // Start is called before the first frame update
    void Start()
    {
       // first_time_run = PlayerPrefs.GetInt("First_run");
        Debug.Log(PlayerPrefs.GetInt("First_run"));
        if (PlayerPrefs.GetInt("First_run")== 0)
        {
            Debug.Log("It is stuck playing in here");
            firstPlay = 0.5f; 
            backgroundSlider.value = firstPlay; //Setting the slider volume from memory
            backgroundAudio.volume = backgroundSlider.value; //Setting the volume to the slider volume 
            PlayerPrefs.SetInt("First_run",1);
         //    PlayerPrefs.Save();
        }
            
        else{
        backgroundSlider.value = firstPlay; //Setting the slider volume from memory
        backgroundAudio.volume = backgroundSlider.value; //Setting the volume to the slider volume 
        }
       
       
    }



   

    void Update()
    {
        backgroundAudio.volume = backgroundSlider.value;
        PlayerPrefs.SetFloat("FirstPlay", backgroundAudio.volume);        
    }
}
