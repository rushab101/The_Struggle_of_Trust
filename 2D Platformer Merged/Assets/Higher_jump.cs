using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Higher_jump : MonoBehaviour
{
    public bool high_jump = false;
    
     void OnCollisionStay2D(Collision2D collision)
    {
       
           high_jump = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
           high_jump = true;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        high_jump = true;
    }

     private void OnTriggerExit2D(Collider2D collision) {
        high_jump = false;
    }


     void OnCollisionExit2D(Collision2D collision)
    {
       
       high_jump = false;
    }

}
