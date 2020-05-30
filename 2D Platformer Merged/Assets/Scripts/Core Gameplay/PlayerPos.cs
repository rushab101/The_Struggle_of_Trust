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
   }

    

   void Start()
   {
       
       gm=GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
         //LoadPlayer();
       
         if (Checking == 1)
         {
               Vector2 position;
                position.x = 116.2f;
                 position.y= -28.90263f;
                transform.position = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
         else if (Checking == 2)
         {
              Vector2 position;
                position.x = -84.52002f;
                 position.y= 12.79238f;
                transform.position = position;
                PlayerPrefs.SetFloat("Check1",0);
         }
        else 
        {
          //  LoadPlayer();
        }
     
    
   }

   void Update()
   {
     // Checking =  PlayerPrefs.GetFloat("Check1");
   }


   public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector2 position;
        position.x = data.position[0];
        position.y= data.position[1];
        transform.position = position;
        

    }

   

}
