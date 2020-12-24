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



   public void SavePlayer(float x, float y)
   {
       SaveSystem.SavePlayer(x, y);
   }



}
