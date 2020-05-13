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

  public  void OnCollisionEnter2D(Collider2D collider)
{
 
    Debug.Log("Went to collisons");
 
}



    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Sword"))
        {
            Debug.Log("Went to collisons");
        }


        else if (collision.CompareTag("Player")) {

            FindObjectOfType<TimeStop>().StopTime(0.05f, 10, 0.1f);
           // UnityEngine.Debug.Log("Timestop TRUE (Spikes)");

            FindObjectOfType<PlayerStats>().TakeDamage(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");

            FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
          //  UnityEngine.Debug.Log("Knockback TRUE (Spikes)");
        }
    }

}
