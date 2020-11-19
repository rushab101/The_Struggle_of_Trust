using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningOnWoodSFX : MonoBehaviour
{

public bool in_wood = false;
public int counter  =0;
    
         private void OnTriggerStay2D(Collider2D collision)
    {
      in_wood  = true;
   
        
    }

    
         private void OnTriggerExit2D(Collider2D collision)
    {
      in_wood  = false;
   
        
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
