using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMoving : MonoBehaviour
{

     [SerializeField]
       private Vector3 velocity;
   public bool moving;

      private Vector3 initialPosition;

      
    private bool resetPlatform=false;
    public bool right = false;
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
            //   moving = false;
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
            if (up)
            {
                 velocity = new Vector3(0,5,0);
                 transform.localPosition+=(velocity * Time.deltaTime);
                 if (transform.localPosition.y  >= 20){
                    up = false;
                    right = true;
                 }
            }
            else if (right){
                velocity = new Vector3(-5,0,0);
                 transform.localPosition+=(velocity * Time.deltaTime);
                 if (transform.localPosition.x  <= 129){
                    right = false;
                    resetPlatform = true;
                    moving =  false;
                 }


            }
            else{
                resetPlatform=true;
            }

            
            Debug.Log(transform.localPosition);
        }


        else if (resetPlatform)
        {
           
               // velocity = new Vector3(5,0,0);
                 transform.localPosition = Vector3.MoveTowards(transform.localPosition, initialPosition, 20f *Time.deltaTime);
                 
             
        }

    }






}
