using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2 : MonoBehaviour
{
      private void OnTriggerEnter2D(Collider2D collision) 
    {
    
         PlayerPrefs.SetFloat("Check1", 2);
                           
          SceneManager.LoadScene("CaveEntrance");


     
       
       
    }
}
