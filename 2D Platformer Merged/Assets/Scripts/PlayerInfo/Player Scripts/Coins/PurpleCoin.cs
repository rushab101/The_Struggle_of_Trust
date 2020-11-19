using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCoin : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
       // Debug.Log("Went to here");
        FindObjectOfType<AudioManager>().Play("coins");
             FindObjectOfType<Currency>().UpdateBalance(5);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");
          // Destroy(gameObject,0.02f);
           gameObject.SetActive(false);
          
        }
    }

}
