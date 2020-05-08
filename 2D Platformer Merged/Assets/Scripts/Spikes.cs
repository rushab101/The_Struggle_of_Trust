using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private PlayerHealth player;
    private PlayerController pc;

    private bool hitSpike = false;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        pc = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {

            FindObjectOfType<PlayerHealth>().EndGame();
            UnityEngine.Debug.Log("flag 1");

            FindObjectOfType<PlayerController>().GetFacingDirection;
            UnityEngine.Debug.Log("flag 2");
        }
    }

}
