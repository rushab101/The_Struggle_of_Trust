using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContineFire : MonoBehaviour
{
    // Start is called before the first frame update

     private GameMaster gm;
     bool first = false;
     float heal;
  

    private void Start()
    {
         gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }


      private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKey(KeyCode.E) && !first )
        {
             Debug.Log("Went to here");
         //   first = true;
            gm.lastCheckPointPos = transform.position;
            heal =  FindObjectOfType<PlayerStats>().MaxHealth; 
            FindObjectOfType<PlayerStats>().Heal(heal);
            SavePlayer(gm.lastCheckPointPos.x, gm.lastCheckPointPos.y);
            PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
            FindObjectOfType<Currency>().SaveSettings();
        }
    }



    public void SavePlayer(float x, float y)
    {
        SaveSystem.SavePlayer(x, y);
    }






    private void OnTriggerExit2D(Collider2D collision)
    {
        first = false;
    }
}
