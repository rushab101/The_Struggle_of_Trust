using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{

    public Text Current_Value;
    private float total_currency;
    private float total_currency_temp;
    void Awake()
    {
        total_currency_temp = PlayerPrefs.GetFloat("Money");
        total_currency = PlayerPrefs.GetFloat("Money");

    }
    // Start is called before the first frame update

    private void Green_coin() //1
    {
        total_currency_temp += 1;
         PlayerPrefs.SetInt("State", 1);
        
    }

    private void Blue_coin() //2
    {
        total_currency_temp += 5;
         PlayerPrefs.SetInt("State", 1);
    }

    private void Yellow_coin() //3 
    {
        total_currency_temp += 10;
         PlayerPrefs.SetInt("State", 1);
    }


    private void Red_coin() //4
    {
        total_currency_temp += 20;
         PlayerPrefs.SetInt("State", 1);
    }

    private void Purple_coin() //5
    {
        total_currency_temp += 50;
         PlayerPrefs.SetInt("State", 1);

    }



    public void UpdateBalance(int coin)
    {

       
        switch (coin)
        {
            case 1:
                Green_coin();
                break;
            case 2:
                Blue_coin();
                break;
            case 3:
                Yellow_coin();
                break;
            case 4:
                Red_coin();
                break;
            case 5:
                Purple_coin();
                break;
        }

    }




    void Start()
    {
        if (PlayerPrefs.GetFloat("Money") == 0f)
        {
            total_currency = 0;
        }

    }

    public void SaveSettings()
    {
        
      //  PlayerPrefs.SetFloat("Money", total_currency);
      //  PlayerPrefs.Save();
      Debug.Log("Went into coins");
       PlayerPrefs.SetInt("State", 2);
       Debug.Log("State value is" + (PlayerPrefs.GetInt("State")));
       PlayerPrefs.SetFloat("Money",total_currency_temp);
     //  PlayerPrefs.SetInt("State", 2);
    

    }


    void OnApplicationQuit()
    {
        Debug.Log("State value is" + (PlayerPrefs.GetInt("State")));
        if (PlayerPrefs.GetInt("State") == 1) //Does not save
        {
           // total_currency = PlayerPrefs.GetInt("Money");
             PlayerPrefs.SetFloat("Money",total_currency);

        }
        if (PlayerPrefs.GetInt("State") == 2) // Saves 
        {
            SaveSettings();
        }
       
            

    }

    void ResetVal()
    {
        Debug.Log("State value is" + (PlayerPrefs.GetInt("State")));
        if (PlayerPrefs.GetInt("State") == 1) //Does not save
        {
           // total_currency = PlayerPrefs.GetInt("Money");
             PlayerPrefs.SetFloat("Money",total_currency);

        }
        if (PlayerPrefs.GetInt("State") == 2) // Saves 
        {
            SaveSettings();
        }
       

    }


    // Update is called once per frame
    void Update()
    {
        Current_Value.text = total_currency_temp.ToString("0");
        PlayerPrefs.SetFloat("Money", total_currency_temp);
        if (FindObjectOfType<PlayerStats>().GameOver)
        {
            ResetVal();
        }
      //  Debug.Log("State value is" + (PlayerPrefs.GetInt("State")));

    }
}
