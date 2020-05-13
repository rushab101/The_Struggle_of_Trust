using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

/*    private PlayerHealth player;
    private PlayerController pc;


    private bool hitSpike = false;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        pc = GetComponent<PlayerController>();
    }*/

     private bool hitSpike = true;




    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Sword"))
        {   
          
            Debug.Log(FindObjectOfType<PlayerCombatController>().anim.GetBool("downAttack"));
            
            if ( FindObjectOfType<PlayerCombatController>().anim.GetBool("downAttack"))
            {       
                  hitSpike = false;
                   FindObjectOfType<PlayerController>().rb.velocity = new Vector2(0, 30);
            }
            else  if ( !FindObjectOfType<PlayerCombatController>().anim.GetBool("downAttack"))
            {       
                    FindObjectOfType<TimeStop>().StopTime(0.05f, 10, 0.1f);
           // UnityEngine.Debug.Log("Timestop TRUE (Spikes)");

            FindObjectOfType<PlayerStats>().TakeDamage(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");

            FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
            }


            else {
                hitSpike = true;
                }
   
          //  hitSpike = true;
        }


        if (collision.CompareTag("Player") && hitSpike) {

            FindObjectOfType<TimeStop>().StopTime(0.05f, 10, 0.1f);
           // UnityEngine.Debug.Log("Timestop TRUE (Spikes)");

            FindObjectOfType<PlayerStats>().TakeDamage(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");

            FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
          //  UnityEngine.Debug.Log("Knockback TRUE (Spikes)");
        }
    }

}
