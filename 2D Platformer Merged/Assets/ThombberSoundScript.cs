using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThombberSoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Play_thombber_sound = false;
    public string a;
   

    void Start()
    {

    }

private void Update() {
    
}
    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            
             FindObjectOfType<AudioManager>().Play(a); // 06 June 2020

            
        }
    }
    public void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
           // Debug.Log("Went into this thing");
            // FindObjectOfType<AudioManager>().Play("LavaSFX"); // 06 June 2020
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
          if (collision.CompareTag("Player"))
        {
          FindObjectOfType<AudioManager>().Pause(a); // 06 June 2020
        }
       
    }

}