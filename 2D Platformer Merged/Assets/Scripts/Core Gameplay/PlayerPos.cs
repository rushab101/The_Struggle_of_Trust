using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
   private GameMaster gm;


   void Start()
   {
       
       gm=GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
       LoadPlayer();
      // gm.lastCheckPointPos.x=PlayerPrefs.GetFloat("XPosition");
     //  gm.lastCheckPointPos.y=PlayerPrefs.GetFloat("yPosition");
     //  transform.position = gm.lastCheckPointPos;
   }

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.T))
      {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
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
