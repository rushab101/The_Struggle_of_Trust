using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator anim;
    private bool went_it= false;
    public bool open_Gate= false;
    public GameObject a;
    public GameObject b;
     private void OnTriggerStay2D(Collider2D collision) 
    {
          
       
        if (Input.GetKey(KeyCode.Z) && !went_it)
        {
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
      
        
             anim.SetBool("done",false);
             anim.SetBool("cancel",true);
              a.SetActive(false);
              b.SetActive(false);
             open_Gate = true;
     
        
    
    }
}
