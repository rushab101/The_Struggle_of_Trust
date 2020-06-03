using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_player : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

     private void OnTriggerEnter2D(Collider2D collision) {
         if (collision.CompareTag("Player"))
         {
              FindObjectOfType<TimeStop>().StopTime(0.05f, 10, 0.1f);
           // UnityEngine.Debug.Log("Timestop TRUE (Spikes)");
           // FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
            FindObjectOfType<PlayerStats>().TakeDamage(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");
            player.transform.position = respawnPoint.transform.position;
         }
         
        
    }

}
