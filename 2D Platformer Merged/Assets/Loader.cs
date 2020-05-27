using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
     public GameObject Interior;
     public GameObject Exterior;
     private float x;
     private float y;
    


     void Awake()
     {
         LoadPlayer();
         Debug.Log(x);
         Debug.Log(y);
         if (x > - 60)
         {
             Interior.SetActive(false);
             Exterior.SetActive(true);
         }
         else if (x < -60)
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
