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
     //  Debug.Log(Checking);
      //LoadPlayer();
     //Checking = 3;
       
       
       
         if (Checking == 1f) //At the house
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
         else if (Checking == 2f) //At the Cave Entrance
         {
                Debug.Log("in the Scene Cave Entrace");
              Vector2 position;
                position.x = -84.52002f;
                 position.y= 12.79238f;
                transform.position = position;
                 Debug.Log(transform.position);
                  Debug.Log("Out of the Scene Cave Entrace");
                PlayerPrefs.SetFloat("Check1",0);
         }
         
         else if (Checking == 3f) //Left Cave Entrance and entered Cave Middle
         {
          
                Vector3 position;
                position.x = 60.78f;
                 position.y= -16.78f;
                 position.z = 10.47732f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
         else if (Checking == 3.1f)
         {
                LoadPlayer();
         }
         else if (Checking == 4f) //Left Cave Middle and entered Cave Entrance
         {
          
                Vector3 position;
                position.x = 65.09f;
                 position.y= -12.53f;
                 position.z = 10.47732f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
          else if (Checking == 5f) //Left Cave Middle and entered Boss Entrance
         {
                Debug.Log("I am in here now");
                Vector3 position;
                position.x = 308.07f;
                 position.y= 0.2476334f;
                 position.z = 0f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
          else if (Checking == 6f) //Left Boss Entrance and entered Cave Entrance
         {
          
                Vector3 position;
                position.x = 214.75f;
                 position.y= -24.91f;
                 position.z = 10.47732f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
         else if (Checking == 7f) //Leave Boss Entrance and entered Cave Exit
         {
          
                Vector3 position;
                position.x = 229.72f;
                 position.y= 61.59f;
                 position.z = 46.4f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
          else if (Checking == 8f) //Leave Cave Exit and entered Boss Entrance
         {
          
                Vector3 position;
                position.x = 491.51f;
                 position.y= 26.21f;
                 position.z = 0f;
                transform.localPosition = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
         
         
         
        else 
        {
      LoadPlayer();
        }
     
    
   }

   void Update()
   {
//          UnityEngine.Debug.Log(transform.position);
     // Checking =  PlayerPrefs.GetFloat("Check1");
   }


   public void LoadPlayer()
    {
       FindObjectOfType<PlayerStats>().ResetHealth();
        PlayerData data = SaveSystem.LoadPlayer();
        Debug.Log("In load Player");
        Debug.Log(transform.position);
        Debug.Log("Out of load player");
        Vector3 position;
        position.x = data.position[0];
        position.y= data.position[1];
        position.z = data.position[2];
        transform.position = position;
        

    }

   

}
