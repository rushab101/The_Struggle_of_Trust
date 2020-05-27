using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomerSault : MonoBehaviour
{

    public GameObject canvas;
    bool first = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        
    }

     private void OnTriggerEnter2D(Collider2D collision) 
    {
      
         if (collision.CompareTag("Player") && !first)
        {
                canvas.SetActive(true);
              // first=true;
                 
        }
  

    }

    private void OnTriggerExit2D( Collider2D collision ) 
    {
       canvas.SetActive(false);
       
    }

    // Update is called once per frame
   
}
