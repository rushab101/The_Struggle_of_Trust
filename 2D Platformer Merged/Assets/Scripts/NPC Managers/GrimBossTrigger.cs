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
    public GameObject shroom1;
    public GameObject shroom2;
    public GameObject boss;
    public bool boos_is_dead = false;
     public Canvas canvas;

    public bool boss_dead_save = false;

    bool went_in = false;
    public AudioSource audio;

    void Start()
    {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        D.SetActive(false);
        E.SetActive(false);
        shroom1.SetActive(false);
        shroom2.SetActive(false);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player") && !went_in)
        {
            audio.Play();
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
     
        if (!boss.active &&  boos_is_dead)
        {
            FindObjectOfType<TriggerScythBoss>().audio.Pause();
            PlayerPrefs.SetInt("boss_save",2);
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(Test_S());
            StartCoroutine(Tes());
            StartCoroutine(Tes2());
            StartCoroutine(Tes3());
            StartCoroutine(Tes4());
            StartCoroutine(Tes5());
            shroom1.SetActive(true);
            shroom2.SetActive(true);

        }

    }

     IEnumerator Test_S()
    {
        yield return new WaitForSecondsRealtime(1.0f);
      //  yield return new WaitForRealSeconds(1.0f);
        //  Debug.Log("Hi");
        //  anim.SetBool("setAttack", false);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        //  anim.SetBool("downAttack",false);
        // Debug.Log("flag 2");
        // SceneManager.LoadScene("Game Over");
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
