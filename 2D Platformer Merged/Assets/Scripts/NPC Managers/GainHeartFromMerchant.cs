using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHeartFromMerchant : MonoBehaviour
{
        public GameObject enter_pay_menu;
        

    int checker = 0;
        void Awake()
        {
           checker = PlayerPrefs.GetInt("boss_pop_up");
        }
  
    // Start is called before the first frame update
    void Start()
    {
        
        enter_pay_menu.SetActive(false);
      //  PlayerPrefs.DeleteAll();
        
    }

    public void EnterMenu()
    {
        FindObjectOfType<PauseMenu>().GameIsPaused = true;
        enter_pay_menu.SetActive(true);
        Time.timeScale = 0f;
    }

     public  void Resume()
    {
        FindObjectOfType<PlayerStats>().AddHealth();
        enter_pay_menu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<PauseMenu>().GameIsPaused = false;
    }
  



}
