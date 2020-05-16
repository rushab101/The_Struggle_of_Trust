using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
   [SerializeField]
   private Vector3 velocity;
   private bool moving;
   private bool resetPlatform=false;
   private Vector3 initialPosition;

   void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
          
        }
    }

      void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
               moving = false;
            collision.collider.transform.SetParent(null);
         
        }
    }

     void Start()
 {
     initialPosition = transform.position;
 }

    private void FixedUpdate()
    {
        if (moving)
        {
            
            if (transform.position.x < 238)
            {
                 transform.position +=(velocity * Time.deltaTime);
            }
            else if (transform.position.x > 238)
            {
                velocity = new Vector3(0,5,0);
                 transform.position +=(velocity * Time.deltaTime);
            }
            else if (transform.position.y > 28)
            {
                moving = false;
            }
           resetPlatform=true;
            Debug.Log(transform.position);
           
        }
        else if (resetPlatform && !moving)
        {
           
           
                velocity = new Vector3(5,0,0);
                 transform.position = Vector3.MoveTowards(transform.position, initialPosition, 20f *Time.deltaTime);
                 
             
        }

    }

   
    
}
