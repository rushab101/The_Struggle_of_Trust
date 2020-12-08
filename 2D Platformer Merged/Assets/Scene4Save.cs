using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4Save : MonoBehaviour
{
    public GameObject doorTrigger;
    public GameObject mush1;
    public GameObject scyth;
    public GameObject mush2;
    int counter = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        doorTrigger.SetActive(true);
        scyth.SetActive(true);
        mush1.SetActive(false);
        mush2.SetActive(false);
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerPrefs.GetInt("boss_save") == 2)
        {

            if (counter == 200)
            doorTrigger.SetActive(false);
            scyth.SetActive(false);
            mush1.SetActive(true);
            mush2.SetActive(true);
            counter++;

        }
    }


    
}
