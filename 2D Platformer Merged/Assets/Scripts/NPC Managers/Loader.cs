using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
     public GameObject Interior;
     public GameObject Exterior;
     private float x;
     private float y;
    float Checking;


     void Awake()
     {
         Checking =  PlayerPrefs.GetFloat("Check1");

         if (Checking != 1.1f)
         {
             Interior.SetActive(false);
             Exterior.SetActive(true);
         }
         else if (Checking == 1.1f)
         {
             Interior.SetActive(true);
             Exterior.SetActive(false);
         }
       
     }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        x = data.position[0];
        y = data.position[1];
    }

}
