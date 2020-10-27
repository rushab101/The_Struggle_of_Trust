using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
   [SerializeField]
   private Vector3 velocity;
   public bool moving;
   private bool resetPlatform=false;
   private bool move_right = false;
   public bool end = false;
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
     initialPosition = transform.localPosition;
 }

    private void FixedUpdate()
    {
        if (moving)
        {
            if (transform.localPosition.y  >= -65)
            {
               //  velocity = new Vector3(5,0,0);
                 transform.localPosition+=(velocity * Time.deltaTime);

                 move_right = true;

            }
            else if (move_right){
                    velocity = new Vector3(0,0,0);
                 transform.localPosition +=(velocity * Time.deltaTime);
            }
            else if (end){
                 velocity = new Vector3(0,0,0);
                 transform.localPosition +=(velocity * Time.deltaTime);
            }
            
            
            resetPlatform=true;
            Debug.Log(transform.localPosition);
        }


        else if (resetPlatform && !moving)
        {
           
           
               // velocity = new Vector3(5,0,0);
                 transform.localPosition = Vector3.MoveTowards(transform.localPosition, initialPosition, 20f *Time.deltaTime);
                 
             
        }

    }

   
    
}
