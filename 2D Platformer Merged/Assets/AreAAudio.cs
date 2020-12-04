using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreAAudio : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audio;
    void Start()
    {
       //  audio.volume = 0f;
        audio.Pause();   
    }
   private void OnTriggerEnter2D(Collider2D collision) {
         if (collision.CompareTag("Player"))
            audio.Play();
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
            audio.Pause(); 
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
