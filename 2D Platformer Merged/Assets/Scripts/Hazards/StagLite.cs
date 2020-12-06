using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagLite : MonoBehaviour
{
  

    public float FallSpeed = 0.1f;
    [SerializeField]
   private Vector3 velocity;
  
    public float ySetYGoal;



    // Start is called before the first frame update
    void Start()
    {
        
    }

     public void PlayStagSound()
   {
      FindObjectOfType<AudioManager>().Play("StagA"); // 06 June 2020
   }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if ( FindObjectOfType<Trigger>().ApplyVol)
        {
            if (transform.localPosition.y >= ySetYGoal)
            {
                //Debug.Log(transform.position.y);
                transform.localPosition +=(velocity * Time.deltaTime);
            }
            else 
            {
           //     Debug.Log("IN HERE");
                transform.localPosition +=(Vector3.zero * Time.deltaTime);
            }
            
        }
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision) {
       
     

           
              
            
   
       


        if (collision.CompareTag("Player") &&   !FindObjectOfType<Trigger>().noDamage) {

            FindObjectOfType<TimeStop>().StopTime(0.05f, 10, 0.1f);
           // UnityEngine.Debug.Log("Timestop TRUE (Spikes)");

            FindObjectOfType<PlayerStats>().TakeDamage(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");

            FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
          //  UnityEngine.Debug.Log("Knockback TRUE (Spikes)");
        
    }
    }



}
