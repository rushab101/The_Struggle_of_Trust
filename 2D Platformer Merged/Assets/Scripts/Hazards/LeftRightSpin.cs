using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightSpin : MonoBehaviour
{
   
      public Rigidbody2D body2d;
      public  Vector2 start;
      public  Vector2 target;
     public float velocity = 10f;

    public  float speed = 7f;
    public float delta = 5f;  //delta is the difference between min x to max x.
    public float startingDistance=0f;
    public float y=0f;
        

    // Start is called before the first frame update
    void Start()
    {

      
            
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = startingDistance+Mathf.PingPong(speed * Time.time, delta); 
         Vector3 pos = new Vector3(x, y, 0);
         transform.position = pos;
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
