using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
       
        if (collision.CompareTag("Sword"))
        {   
//           Debug.Log("Checker Done");
            
            
                  if ( FindObjectOfType<PlayerCombatController>().downAttacking)
                  {
                      FindObjectOfType<AudioManager>().Play("bounce");
                       FindObjectOfType<PlayerController>().rb.velocity = new Vector2(0, 40);
                  }
                  
        
        }
    }

}
