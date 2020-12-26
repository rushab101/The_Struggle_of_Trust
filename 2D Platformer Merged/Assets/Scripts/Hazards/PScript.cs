using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PScript : MonoBehaviour
{
    //   [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    private PlayerController player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Its in here");
        if (collision.CompareTag("Player") && ((FindObjectOfType<Lever>().open_portal) || (FindObjectOfType<Lever2>().open_portal) || (FindObjectOfType<Lever3>().open_portal) || (FindObjectOfType<Lever4>().open_portal)))
        {
            // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");
            player.transform.position = respawnPoint.transform.position;
        }

    }
}
