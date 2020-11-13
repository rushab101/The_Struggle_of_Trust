using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrikeScript : MonoBehaviour
{
    public GameObject a;
    public bool reset = false;
    public Animator animator;
    int counter = 0;

    void start()
    {
        animator.SetBool("strike",true);
        a.SetActive(true);
    }
    void Update()
    {
      counter++;
      if (counter == 120){
           animator.SetBool("strike",false);
      }
     if (counter == 800)
     {
         animator.SetBool("strike",true);
         counter = 0;
     }
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            FindObjectOfType<TimeStop>().StopTime(0.05f, 10, 0.1f);
            // UnityEngine.Debug.Log("Timestop TRUE (Spikes)");

            FindObjectOfType<PlayerStats>().TakeDamage(1f);
            // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");

            FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
            //  UnityEngine.Debug.Log("Knockback TRUE (Spikes)");

        }
    }
   
 
 

    
    





}
