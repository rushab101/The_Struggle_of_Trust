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
    



    // Start is called before the first frame update
    void Start()
    {
         SpawnBoss.SetActive(false); 
          LightningA.SetActive(false);
          LightB.SetActive(false);
          BossName.SetActive(false);
         
    }
   

    
       private void OnTriggerStay2D(Collider2D collision) 
    {
       
        if (Input.GetKey(KeyCode.Z))
        {
               counter++;
        }

      

      
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<CounterScript>().counter == 6)
        {
            SpawnBoss.SetActive(true);
             Axe.SetActive(false);
             BossName.SetActive(true);
            counter++;
            audio.Play();  
        }
        
       
        
    }
}
