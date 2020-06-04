using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCoin : MonoBehaviour
{
     void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
        Debug.Log("Went to here");
             FindObjectOfType<Currency>().UpdateBalance(2);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");
           Destroy(gameObject,0.02f);
          
        }
    }

      void Start()
    {
           StartCoroutine(Test());
        
    }

       IEnumerator Test()
    {
        
        yield return new WaitForSeconds(3.0f);
       Destroy(gameObject);
    }


}
