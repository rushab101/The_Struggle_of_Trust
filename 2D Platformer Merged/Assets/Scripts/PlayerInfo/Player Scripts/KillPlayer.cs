using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    [SerializeField]Transform spawnPoint;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player")) { // Checks if the character; tagged as "Player"
            collision.transform.position = spawnPoint.position; // Takes Player position then sets to spawn position
            FindObjectOfType<PlayerStats>().TakeDamage(1f);
        }
    }
}
