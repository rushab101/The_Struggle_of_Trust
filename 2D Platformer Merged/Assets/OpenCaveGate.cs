using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCaveGate : MonoBehaviour
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
        Resume();
        StartCoroutine(Test_T1());
        StartCoroutine(Test_T2());
        StartCoroutine(Test_T3());
        StartCoroutine(Test_T4());
        StartCoroutine(Test_T5());
        StartCoroutine(Test_T6());
        StartCoroutine(Test_T7());
    }

     public  void Resume()
    {
        enter_pay_menu.SetActive(false);
        Time.timeScale = 1f;
    }

       IEnumerator Test_T1()
    {
        
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }
    IEnumerator Test_T2()
    {
       
        yield return new WaitForSeconds(1.0f);
         FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }
    IEnumerator Test_T3()
    {
        
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }
    IEnumerator Test_T4()
    {
        
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }
    IEnumerator Test_T5()
    {
        
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }
    IEnumerator Test_T6()
    {
        
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }
     IEnumerator Test_T7()
    {
        yield return new WaitForSeconds(1.0f);
          GateOpen = true;
    }
        



    // Update is called once per frame
    void Update()
    {
        
    }
}
