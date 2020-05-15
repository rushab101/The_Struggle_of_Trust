using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHp : MonoBehaviour
{

private GameObject aliveGO; 
     private void Start() {
     

     //   pc = GameObject.Find("Player").GetComponent<PlayerController>();

        aliveGO = transform.Find("Hearts").gameObject; 

        //brokenTopGO = Find("Hearts").gameObject; 
      
        //Debug.Log(aliveGO);
      //  Instantiate(aliveGO);
      
    }

  
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
