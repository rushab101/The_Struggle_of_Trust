using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHp : MonoBehaviour
{

  
    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
             FindObjectOfType<PlayerStats>().Heal(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");
           Destroy(gameObject);
          
        }
    }
}
