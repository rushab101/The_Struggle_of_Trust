using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGreen : MonoBehaviour
{

     public bool fell_in = false;
       private void OnTriggerEnter2D(Collider2D collision) {
         if (collision.CompareTag("Player"))
         {
            Debug.Log("Its in heree");
             fell_in = true;
         }
    }

}
