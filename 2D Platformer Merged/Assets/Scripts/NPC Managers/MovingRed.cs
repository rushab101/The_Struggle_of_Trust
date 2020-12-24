using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRed : MonoBehaviour
{
[SerializeField]
       private Vector3 velocity;
   public bool moving;

      private Vector3 initialPosition;

      
    private bool resetPlatform=false;
    public bool down = false;
    public bool up = true;



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
             //  moving = false;
            collision.collider.transform.SetParent(null);
         
        }
    }

      void Start()
    {
        initialPosition = transform.localPosition;
    }

       private void FixedUpdate()
    {
      //  if (moving)
        
            if (up)
            {
                 velocity = new Vector3(0,5,0);
                 transform.localPosition+=(velocity * Time.deltaTime);
                 if (transform.localPosition.y  >= -70){
                    up = false;
                    down =  true;
            
                 }
            }
            if (down)
            {
                velocity = new Vector3(0,-5,0);
                 transform.localPosition+=(velocity * Time.deltaTime);
                 if (transform.localPosition.y  <= -91){
                    up = true;
                    down =  false;
            
                 }



            }

           
}
}