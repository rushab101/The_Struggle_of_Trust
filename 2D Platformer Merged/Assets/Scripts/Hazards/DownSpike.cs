using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSpike : MonoBehaviour
{

      public Rigidbody2D body2d;
      public  Vector2 start;
      public  Vector2 target;
     public float velocity = 10f;

    public  float speed = 7f;
    public float delta = 5f;  //delta is the difference between min y to max y.
    public float startingDistance=4.8f;
        

    // Start is called before the first frame update
    void Start()
    {

         start = new Vector2(0,0);
         target= new Vector2(0,4);
            body2d = GetComponent<Rigidbody2D>();
            
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = startingDistance+Mathf.PingPong(speed * Time.time, delta); 
         Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
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
