using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCoin : MonoBehaviour
{
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player" )
        {
            
     //   Debug.Log("In Collision");
         FindObjectOfType<AudioManager>().Play("coins");
             FindObjectOfType<Currency>().UpdateBalance(1);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");
           Destroy(gameObject,0.02f);
          
        }
    }

   
    void Update()
    {
        if (FindObjectOfType<CreatesCoin>().green_coin_activate)
        {
            StartCoroutine(Test());
        }
    }

       IEnumerator Test()
    {
        
        yield return new WaitForSeconds(3.0f);
       Destroy(gameObject);
    }
}
