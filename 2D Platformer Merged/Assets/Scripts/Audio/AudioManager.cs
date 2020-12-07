using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake() {

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        // Adding audio source in other scripts e.g. running => FindObjectOfType<AudioManager>().Play(Name);
    }

     public void Pause(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        // Adding audio source in other scripts e.g. running => FindObjectOfType<AudioManager>().Play(Name);
    }



}
