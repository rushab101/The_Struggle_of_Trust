using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{

    public Text Current_Value;
    private float total_currency;
    void Awake()
    {
        total_currency =PlayerPrefs.GetFloat("Money");

    }
    // Start is called before the first frame update

    private void Green_coin() //1
    {
        total_currency +=1;
        //Debug.Log(total_currency);
    }

      private void Blue_coin() //2
    {
        total_currency +=5;
    }

       private void Yellow_coin() //3 
    {
        total_currency +=10;
    }

    
     private void Red_coin() //4
    {
        total_currency +=20;
    }

    private void Purple_coin() //5
    {
        total_currency +=50;
         
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
        if (PlayerPrefs.GetFloat("Money")==0f)
        {
            total_currency = 0;
        }

    }

     public void SaveSettings()
    {

        PlayerPrefs.SetFloat("Money", total_currency);
        PlayerPrefs.Save();

    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus == false)
        {
            // UnityEngine.Debug.Log("message");
            SaveSettings();
        }
    }


    // Update is called once per frame
    void Update()
    {
        Current_Value.text = total_currency.ToString("0");
        
    }
}
