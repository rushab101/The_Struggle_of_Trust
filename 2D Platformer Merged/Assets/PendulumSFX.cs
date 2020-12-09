using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumSFX : MonoBehaviour
{
   public AudioSource audio;



    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            
             audio.Play();

            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
          if (collision.CompareTag("Player"))
        {
          audio.Pause();
        }
       
    }




}
