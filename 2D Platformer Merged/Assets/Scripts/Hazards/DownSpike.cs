using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSpike : MonoBehaviour
{

   [SerializeField]
   private Vector3 velocity;
   public bool moving;
   public bool down = true;
   private bool resetPlatform=false;
   private bool up = false;
   public bool end = false;
   public int speed = 5;
   public int down_pos = -9;
   public int up_pos = 11;
   private Vector3 initialPosition;
        

    // Start is called before the first frame update
    void Start()
    {

         initialPosition = transform.localPosition;
         //target= new Vector2(-18,1);
          
            
        
    }

    // Update is called once per frame
      private void FixedUpdate()
    {
        
            if (down){
                velocity = new Vector3(0,-speed,0);
                transform.localPosition+=(velocity * Time.deltaTime);
            
                if (transform.localPosition.y  <= down_pos)
                {
                down = false;
                up =  true;
                
                }
            }
            else if (up){
               velocity = new Vector3(0,speed,0);
                transform.localPosition+=(velocity * Time.deltaTime);
            
                if (transform.localPosition.y  >= up_pos)
                {
                up = false;
                down =  true;
                
                }

            }
           
    }



    
      void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
             FindObjectOfType<PlayerStats>().TakeDamage(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");
           
            FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
        }
    }



}
