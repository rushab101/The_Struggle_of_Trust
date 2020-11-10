using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
   public Animator anim;
    private bool went_it= false;
    public bool open_Gate= false;
    public bool open_portal = false;
  
    public GameObject c;
     public GameObject gate;

    
     private void OnTriggerStay2D(Collider2D collision) 
    {
          
       
        if (Input.GetKey(KeyCode.Z) && !went_it)
        {
            Debug.Log("It went in here");
            c.SetActive(true);
            went_it = true;
             anim.SetBool("done",true);
        
                   
                 StartCoroutine(Test2());
              
    
        
              //  door1.SetActive(false);
             //   door2.SetActive(true);
                
   
        }
    }

    


     IEnumerator Test2()
    {
        
        yield return new WaitForSecondsRealtime(0.2f);
      
            open_portal = true;
            gate.SetActive(false);
             anim.SetBool("done",false);
             anim.SetBool("cancel",true);
           //  open_Gate = true;
     
    }
    
}
