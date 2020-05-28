using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{

    #region Public Variables
    public Rigidbody2D body2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;
    #endregion
    public float direction;
    public bool pendulumHit;
    float counter=0f;

    // Start is called before the first frame update
  
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshold;
        pendulumHit = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Push();
        
        if ( FindObjectOfType<PlayerController>().PendulumHit)
        { 
            counter++;
        }
        if (counter >= 50f)
        {
            
            FindObjectOfType<PlayerController>().PendulumHit = false;
            counter = 0f;
        }
        
    }

       public void Push()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < rightPushRange && (body2d.angularVelocity > 0)&& body2d.angularVelocity < velocityThreshold)
        {
            body2d.angularVelocity = velocityThreshold;
        }
        else if (transform.rotation.z < 0 && transform.rotation.z > leftPushRange && (body2d.angularVelocity < 0) && body2d.angularVelocity > velocityThreshold * -1)
        {
            body2d.angularVelocity = velocityThreshold * -1;
        }

    }

   


      void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<TimeStop>().StopTime(0.05f, 10, 0.1f);
             FindObjectOfType<PlayerStats>().TakeDamage(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");
            direction = FindObjectOfType<PlayerController>().GetFacingDirection();
          //  FindObjectOfType<PlayerController>().rb.velocity = new Vector2(50 * -direction, 5);
       
          
            FindObjectOfType<PlayerController>().PendulumHit = true;
            FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
        }
    }

      void OnCollisionExit2D(Collision2D collision)
    {
        

        
          //pendulumHit = false;
            
       
    }






       
    }







