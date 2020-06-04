using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayer : MonoBehaviour
{
    public Transform player;

    
     

     void OnCollisionEnter(Collision collision)
    {
         
        
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        
    }
      private void OnTriggerStay2D(Collider2D collision)
    {
         
        
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        
    }


}
