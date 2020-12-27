using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGateScript : MonoBehaviour
{
    public GameObject enter_pay_menu;
    public bool GateOpen = false;
    public AudioSource a;
    // Start is called before the first frame update
    void Start()
    {

        enter_pay_menu.SetActive(false);
        //  PlayerPrefs.DeleteAll();

    }

    public void EnterMenu()
    {
        enter_pay_menu.SetActive(true);
        FindObjectOfType<PauseMenu>().GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void PayNPC()
    {
        float f = FindObjectOfType<Currency>().GetAmount();
 FindObjectOfType<PauseMenu>().canPauseGame = false;
        if (f >= 1500f)
        {
            FindObjectOfType<Currency>().PayAmount(1500);
            GateOpen = true;
            Resume();
            FindObjectOfType<AudioManager>().Play("Paying");
        }
        else
        {
            Debug.Log("Failed Sound effect");
            a.Play();
           // FindObjectOfType<AudioManager>().Play("Fail");
        }



    }

    public void Resume()
    {
         FindObjectOfType<PauseMenu>().canPauseGame = true;
        enter_pay_menu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<PauseMenu>().GameIsPaused = false;
    }





    // Update is called once per frame
    void Update()
    {

    }
}
