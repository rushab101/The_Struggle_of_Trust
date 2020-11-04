using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
   [SerializeField]
   private Vector3 velocity;
   public bool moving;
   public bool down = true;
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
            if (down){
                velocity = new Vector3(0,-5,0);
                transform.localPosition+=(velocity * Time.deltaTime);
            
                if (transform.localPosition.y  <= -65)
                {
                down = false;
                moving =  false;
                resetPlatform = true;
                }
            }
           
            
            resetPlatform=true;
            Debug.Log(transform.localPosition);
        }


        else if (resetPlatform && !moving)
        {
           
            down = true;
            resetPlatform = true;
            moving = false;
                 transform.localPosition = Vector3.MoveTowards(transform.localPosition, initialPosition, 20f *Time.deltaTime);
                 
             
        }

    }

   
    
}
