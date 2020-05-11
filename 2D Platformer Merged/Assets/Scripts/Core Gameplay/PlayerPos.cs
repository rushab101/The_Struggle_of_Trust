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
       gm.lastCheckPointPos.x=PlayerPrefs.GetFloat("XPosition");
       gm.lastCheckPointPos.y=PlayerPrefs.GetFloat("yPosition");
       transform.position = gm.lastCheckPointPos;
   }

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.T))
      {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
   }

   public void SavePlayer()
   {
       SaveSystem.SavePlayer(this);
   }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        

    }

}
