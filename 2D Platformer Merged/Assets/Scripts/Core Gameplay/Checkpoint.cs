using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    void Start()
    {
        gm=GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
  void OnTriggerEnter2D(Collider2D other)
  {
    
      if (other.CompareTag("Player"))
      {  Debug.Log("Went to trigger");
          gm.lastCheckPointPos = transform.position;
        PlayerPrefs.SetFloat("XPosition",gm.lastCheckPointPos.x);
        PlayerPrefs.SetFloat("yPosition",gm.lastCheckPointPos.y);
        
      }
  }



}
