using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    void Start()
    {
        gm=GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    public float x_value;
    public float y_value;
  void OnTriggerEnter2D(Collider2D other)
  {
    
      if (other.CompareTag("Player"))
      {  
          //Debug.Log("Went to trigger");
          gm.lastCheckPointPos = transform.position;
            PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
      //  PlayerPrefs.SetFloat("XPosition",gm.lastCheckPointPos.x);
       // PlayerPrefs.SetFloat("yPosition",gm.lastCheckPointPos.y);
        SavePlayer(gm.lastCheckPointPos.x,gm.lastCheckPointPos.y);
      }
  }

 

   public void SavePlayer(float x, float y)
   {
       SaveSystem.SavePlayer(x, y);
   }



}
