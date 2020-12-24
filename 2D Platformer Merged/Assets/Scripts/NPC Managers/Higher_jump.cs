using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Higher_jump : MonoBehaviour
{
    public bool high_jump = false;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
       
           if (collision.gameObject.tag == "Player")
           {
               if ( FindObjectOfType<PlayerCombatController>().downAttacking)
                  {
                       FindObjectOfType<PlayerController>().rb.velocity = new Vector2(0, 30);
                  }
           }
    }

}
