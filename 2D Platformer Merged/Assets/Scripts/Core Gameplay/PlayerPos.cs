using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
   private GameMaster gm;
   private float Checking;

   void Awake()
   {
       Checking =  PlayerPrefs.GetFloat("Check1");
    //   PlayerPrefs.DeleteAll();
   }

    

   void Start()
   {
       
       gm=GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
       LoadPlayer();

       
       
         if (Checking == 1) //At the house
         {
               Vector2 position;
                position.x = 116.2f;
                 position.y= -28.90263f;
                transform.position = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
         else if (Checking == 1.1f)
         {
                 Vector2 position;
                position.x = -63.2f;
                 position.y= -0.1f;
                transform.position = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
         else if (Checking == 2) //At the Cave Entrance
         {
              Vector2 position;
                position.x = -84.52002f;
                 position.y= 12.79238f;
                transform.position = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
         
         else if (Checking == 3) //Left Cave Entrance and entered Cave Middle
         {
          
                Vector3 position;
                position.x = 60.78f;
                 position.y= -16.78f;
                 position.z = 10.47732f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
         else if (Checking == 4) //Left Cave Middle and entered Cave Entrance
         {
          
                Vector3 position;
                position.x = 65.09f;
                 position.y= -12.53f;
                 position.z = 10.47732f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
          else if (Checking == 5) //Left Cave Middle and entered Boss Entrance
         {
          
                Vector3 position;
                position.x = 220.4f;
                 position.y= -24.9f;
                 position.z = 10.47732f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
          else if (Checking == 6) //Left Boss Entrance and entered Cave Entrance
         {
          
                Vector3 position;
                position.x = 214.75f;
                 position.y= -24.91f;
                 position.z = 10.47732f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
         else if (Checking == 7) //Leave Boss Entrance and entered Cave Exit
         {
          
                Vector3 position;
                position.x = 400.21f;
                 position.y= 1.11f;
                 position.z = 10.47732f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
          else if (Checking == 8) //Leave Cave Exit and entered Boss Entrance
         {
          
                Vector3 position;
                position.x = 404.75f;
                 position.y= 1.13f;
                 position.z = 10.47732f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
         
         
         
        else 
        {

       // LoadPlayer();
        }
     
    
   }

   void Update()
   {
      //    UnityEngine.Debug.Log(transform.position);
     // Checking =  PlayerPrefs.GetFloat("Check1");
   }


   public void LoadPlayer()
    {
       FindObjectOfType<PlayerStats>().ResetHealth();
        PlayerData data = SaveSystem.LoadPlayer();
        Vector2 position;
        position.x = data.position[0];
        position.y= data.position[1];
        transform.position = position;
        

    }

   

}
