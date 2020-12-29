using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudioClip : MonoBehaviour
{

    
    public AudioSource audio;
    float firstPlay;

    void Awake()
    {
         firstPlay = PlayerPrefs.GetFloat("FirstPlay");
    }


    // Start is called before the first frame update
    void Start()
    {
         audio.volume = firstPlay;
            audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
