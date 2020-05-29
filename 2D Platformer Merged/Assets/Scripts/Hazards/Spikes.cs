using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {


     private bool hitSpike = true;




    private void OnTriggerEnter2D(Collider2D collision) {
       
        if (collision.CompareTag("Sword"))
        {   
           Debug.Log("Checker Done");
            
            
                  hitSpike = false;
                  if ( FindObjectOfType<PlayerCombatController>().downAttacking)
                  {
                       FindObjectOfType<PlayerController>().rb.velocity = new Vector2(0, 30);
                  }
                  
        
        }


           
              
            
   
       


        if (collision.CompareTag("Player") && !FindObjectOfType<PlayerCombatController>().downAttacking) {

            FindObjectOfType<TimeStop>().StopTime(0.05f, 10, 0.1f);
           // UnityEngine.Debug.Log("Timestop TRUE (Spikes)");

            FindObjectOfType<PlayerStats>().TakeDamage(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");

            FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
          //  UnityEngine.Debug.Log("Knockback TRUE (Spikes)");
        
    }
    }



     private void OnTriggerExit2D(Collider2D collision) {
      hitSpike = false;
     }

}
