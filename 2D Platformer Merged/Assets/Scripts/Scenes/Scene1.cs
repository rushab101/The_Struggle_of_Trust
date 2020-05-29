using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour
{
    public bool doNotLoadCheckPoint=false;
   

            private void OnTriggerEnter2D(Collider2D collision) 
    {
    
         PlayerPrefs.SetFloat("Check1", 1);
                           
          SceneManager.LoadScene("Beginning");


     
       
       
    }
    


}
