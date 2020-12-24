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
     //   PlayerPrefs.DeleteAll();
    }

    public float x_value;
    public float y_value;



   public void SavePlayer(float x, float y, float z)
   {
       SaveSystem.SavePlayer(x, y,z);
   }



}
