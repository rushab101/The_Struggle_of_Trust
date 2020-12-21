using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGateScript : MonoBehaviour
{
    public GameObject enter_pay_menu;
    public bool GateOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
        enter_pay_menu.SetActive(false);
      //  PlayerPrefs.DeleteAll();
        
    }

    public void EnterMenu()
    {
        enter_pay_menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PayNPC()
    {
        float f = FindObjectOfType<Currency>().GetAmount();
        if (f > 1)
        {
            FindObjectOfType<Currency>().PayAmount(1500);
            GateOpen = true;
            Resume();
             FindObjectOfType<AudioManager>().Play("Paying");
        }
        else{
            Debug.Log("Failed Sound effect");
            FindObjectOfType<AudioManager>().Play("Fail");
        }
        
        

    }

     public  void Resume()
    {
        enter_pay_menu.SetActive(false);
        Time.timeScale = 1f;
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
