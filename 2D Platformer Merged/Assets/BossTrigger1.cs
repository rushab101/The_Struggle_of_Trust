using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger1 : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject F;
    public GameObject G;
    public GameObject H;
    bool went_in = false;

    void Start()
    {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        D.SetActive(false);
        E.SetActive(false);
        F.SetActive(false);
        G.SetActive(false);
        H.SetActive(false);

    }

       private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && !went_in)
        {
           Time.timeScale = 0f;
           went_in = true;
             StartCoroutine(Test());
             StartCoroutine(Test2());
             StartCoroutine(Test3());
             StartCoroutine(Test4());
             StartCoroutine(Test5());
             StartCoroutine(Test6());
             StartCoroutine(Test7());
              StartCoroutine(Test8());

        }


   
        
    }

        IEnumerator Test()
    {
        
        yield return new WaitForSecondsRealtime(0.1f);
       A.SetActive(true);
    }

        IEnumerator Test2()
    {
        
        yield return new WaitForSecondsRealtime(0.2f);
      B.SetActive(true);
    }

        IEnumerator Test3()
    {
        
        yield return new WaitForSecondsRealtime(0.3f);
       C.SetActive(true);
    }

        IEnumerator Test4()
    {
        
        yield return new WaitForSecondsRealtime(0.4f);
      D.SetActive(true);
    }

        IEnumerator Test5()
    {
        
        yield return new WaitForSecondsRealtime(0.5f);
     E.SetActive(true);
    }

        IEnumerator Test6()
    {
        
        yield return new WaitForSecondsRealtime(0.6f);
       F.SetActive(true);
    }
     IEnumerator Test7()
    {
        
        yield return new WaitForSecondsRealtime(0.7f);
       G.SetActive(true);
       Time.timeScale = 1f;
    }
       IEnumerator Test8()
    {
        
        yield return new WaitForSecondsRealtime(1.0f);
       H.SetActive(true);
     
    }


    
}
