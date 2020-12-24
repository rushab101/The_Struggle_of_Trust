using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stag2 : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void PlayStagSound()
   {
      FindObjectOfType<AudioManager>().Play("StagA"); // 06 June 2020
   }

    private void OnTriggerEnter2D(Collider2D collision) {
     //  Debug.Log("Went to here");
      
        
           
              
     
   
       


        if (collision.CompareTag("Player") &&   animator.GetCurrentAnimatorStateInfo(0).IsName("Falling")) {
          
             //Debug.Log("Trigger not working");

            FindObjectOfType<TimeStop>().StopTime(0.05f, 10, 0.1f);
           // UnityEngine.Debug.Log("Timestop TRUE (Spikes)");

            FindObjectOfType<PlayerStats>().TakeDamage(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");

            FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
          //  UnityEngine.Debug.Log("Knockback TRUE (Spikes)");
        
    }
    }
}


