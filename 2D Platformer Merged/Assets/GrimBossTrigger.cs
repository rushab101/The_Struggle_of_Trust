using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimBossTrigger : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject boss;



    bool went_in = false;

    void Start()
    {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        D.SetActive(false);
        E.SetActive(false);
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
          Time.timeScale = 1f;
    }


    void Update()
    {

        if (!boss.active)
        {
            StartCoroutine(Tes());
            StartCoroutine(Tes2());
            StartCoroutine(Tes3());
            StartCoroutine(Tes4());
            StartCoroutine(Tes5());

        }

    }

    IEnumerator Tes()
    {

        yield return new WaitForSecondsRealtime(0.1f);
        A.SetActive(false);
    }

    IEnumerator Tes2()
    {

        yield return new WaitForSecondsRealtime(0.2f);
        B.SetActive(false);
    }

    IEnumerator Tes3()
    {

        yield return new WaitForSecondsRealtime(0.3f);
        C.SetActive(false);
    }

    IEnumerator Tes4()
    {

        yield return new WaitForSecondsRealtime(0.4f);
        D.SetActive(false);
    }

    IEnumerator Tes5()
    {

        yield return new WaitForSecondsRealtime(0.5f);
        E.SetActive(false);
    }
}
