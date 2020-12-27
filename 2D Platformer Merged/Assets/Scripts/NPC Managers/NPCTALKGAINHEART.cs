using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTALKGAINHEART : MonoBehaviour
{
    public GameObject enter_pay_menu;
    public AudioSource a;
  
    // Start is called before the first frame update
    void Start()
    {
        a.Pause();
        enter_pay_menu.SetActive(false);
      //  PlayerPrefs.DeleteAll();
        
    }

    public void EnterMenu()
    {
         FindObjectOfType<PauseMenu>().GameIsPaused = true;

       
        enter_pay_menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PayNPC()
    {
        float f = FindObjectOfType<Currency>().GetAmount();
        if (f >= 500)
        {
            FindObjectOfType<Currency>().PayAmount(500);
            
             Resume();
           // b.Play();
             FindObjectOfType<AudioManager>().Play("Paying");
             FindObjectOfType<PlayerStats>().AddHealth();
             PlayerPrefs.SetInt("GainLife",2);

        }
        else{
            //Debug.Log("Failed Sound effect");
            FindObjectOfType<AudioManager>().Play("Fail");
             a.Play();
        }
        
        

    }

     public  void Resume()
    {
        enter_pay_menu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<PauseMenu>().GameIsPaused = false;
    }
}
