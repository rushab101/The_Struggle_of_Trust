using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScythBoss : MonoBehaviour
{
     public GameObject SpawnBoss;
     public GameObject Axe;
     public GameObject LightningA;
     public GameObject LightB;
     public GameObject BossName;
     int counter = 0;
     public AudioSource audio;
    
    float firstPlay =0f;
      void Awake()
    {
         firstPlay = PlayerPrefs.GetFloat("FirstPlay");
    }


    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
         SpawnBoss.SetActive(false); 
          LightningA.SetActive(false);
          LightB.SetActive(false);
          BossName.SetActive(false);
         
    }
   

    
     
    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<CounterScript>().counter == 1)
        {
            SpawnBoss.SetActive(true);
             Axe.SetActive(false);
             BossName.SetActive(true);
            counter++;
            audio.volume = firstPlay;
            audio.Play();  
        }
        
       
        
    }
}
