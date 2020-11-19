using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCOin : MonoBehaviour
{
     void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
         FindObjectOfType<AudioManager>().Play("coins");
             FindObjectOfType<Currency>().UpdateBalance(4);
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
