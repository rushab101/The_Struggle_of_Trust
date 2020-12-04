using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBAudio : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audio;
    private void Awake() {
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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
